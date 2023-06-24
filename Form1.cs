// Dmitrovskis Martynas IFIN-2/2
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

/*--------------------------------------------------------------------------------------------
    U3-2.Automobilių parkas. 
 Įmonė UAB „Žaibas“ turi du filialus. Pirmoje eilutėje – miestas, antroje – adresas.
Toliau informacija apie transporto priemones (lengvuosius, krovininius automobilius, 
autobusus): [Požymis,] valstybinis numeris, gamintojas, modelis, pagaminimo metai ir mėnuo, 
techninės apžiūros galiojimo data, kuras (dyzelinis, hibridas, elektrinis),[durų skaičius] 
[, priekabos talpa][, sėdimų vietų skaičius].
 Įmonės transporto priemonių parkas sudarytas ne tik iš lengvųjų automobilių, bet ir iš 
krovininių automobilių bei autobusų. Sukurkite klasę „Transport“ (savybės – valstybinis 
numeris, gamintojas, modelis, pagaminimo metai ir mėnuo, techninės apžiūros galiojimo data, 
kuras), kurią paveldės klasės „Car“(savybė – durų skaičius), „Lorry“ (savybė – priekabos talpa)
ir „Bus“ (savybė – sėdimų vietų skaičius).

Problemos:
    Raskite, kuriame filiale transporto priemonės yra seniausios (vidutinis jų amžius 
didžiausias).
    Raskite, kurio,-ių gamintojo,-jų mašinų yra daugiausia, atspausdinkite gamintojo,-jų 
pavadinimą, bei surastą kiekį.
    Sudarykite bendrą sąrašą, į kurį surašomi lengvieji automobiliai, kurių kuras hibridas, 
kroviniai, kurių kuras dyzelis ir autobusai, kurių kuras elektra. Kuro tipas nurodomas 
klaviatūra. Pateikite pilną informaciją apie juos.
    Išrikiuokite sudarytą sąrašą pagal modelį ir valstybinius numerius didėjimo tvarka.
--------------------------------------------------------------------------------------------*/

namespace U3_2_Automobiliu_parkas
{
    public partial class Form1 : Form
    {
        string[] CFd;
        string CFr;

        List<Transport> transportList = new List<Transport>();
        List<Transport> secondTransportList = new List<Transport>();
        List<Transport> finalList = new List<Transport>();
        List<Transport> theLastList = new List<Transport>();
        Dictionary<string, int> transportCount;
        Dictionary<string, int> mostFrequentManufacturers;

        string city1, city2, adress1, adress2;
        string gas;

        public Form1()
        {
            InitializeComponent();
            readDataToolStripMenuItem.Enabled = false;
            printToolStripMenuItem.Enabled = false;
            findBranchToolStripMenuItem.Enabled = false;
            findLargestCountToolStripMenuItem.Enabled = false;
            formattingToolStripMenuItem.Enabled = false;
            sortToolStripMenuItem.Enabled = false;
            setGasTypeToolStripMenuItem.Enabled = true;
        }

        //=========================================================================
        // GRAPHIC USER INTERFACE METHODS
        //=========================================================================

        /// <summary>
        /// Actions of the "Įvesti kuro tipą" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setGasTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gasTypeLabel.Text = "Kuro tipas";
            gas = gasType.Text;

            setGasTypeToolStripMenuItem.Enabled = false;
            readDataToolStripMenuItem.Enabled = true;

            notificationLabel.Text = "Kuro tipas įvestas!";
        }

        /// <summary>
        /// Actions of the "Įvesti pradinius duomenis" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Pasirinkite duomenų failus";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                CFd = openFileDialog1.FileNames;
                ReadTransportList(CFd[0], transportList, out city1, out adress1);
                ReadTransportList(CFd[1], secondTransportList, out city2, out adress2);
            }

            readDataToolStripMenuItem.Enabled = false;
            printToolStripMenuItem.Enabled = true;
            findBranchToolStripMenuItem.Enabled = true;
            findLargestCountToolStripMenuItem.Enabled = true;
            formattingToolStripMenuItem.Enabled = true;
            sortToolStripMenuItem.Enabled = true;

            notificationLabel.Text = "Pradiniai duomenys nuskaityti iš failų\n "
                + CFd[0] + "\n" + CFd[1];
        }

        /// <summary>
        /// Actions of the "Spausdinti" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite rezultatų failą";
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                CFr = saveFileDialog1.FileName;

                if (File.Exists(CFr))
                    File.Delete(CFr);

                PrintTransportList(CFr, transportList, city1, adress1);
                PrintTransportList(CFr, secondTransportList, city2, adress2);
            }

            string resultFile = File.ReadAllText(CFr);
            results.Text = resultFile;
            printToolStripMenuItem.Enabled = false;

            notificationLabel.Text = "Pradiniai duomenys faile\n" + CFr;
        }

        /// <summary>
        /// Actions of the "Baigti" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Actions of the "Seniausių priemonių filialo radimas" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (transportList.Count > 0 && secondTransportList.Count > 0)
            {
                double avg1 = GetAverageYear(transportList);
                double avg2 = GetAverageYear(secondTransportList);

                if (avg1 > avg2)
                {
                    using (var fr = new StreamWriter(File.Open(CFr, FileMode.Append)))
                    {
                        fr.WriteLine("{0} fililale yra seniausios transporto priemonės", 
                            city1);
                    }
                }
                else
                    using (var fr = new StreamWriter(File.Open(CFr, FileMode.Append)))
                    {
                        fr.WriteLine("{0} fililale yra seniausios transporto priemonės", 
                            city2);
                    }
            }
            else
                using (var fr = new StreamWriter(File.Open(CFr, FileMode.Append)))
                {
                    fr.WriteLine("Klaida duomenyse");
                }

            string resultFile = File.ReadAllText(CFr);
            results.Text = resultFile;
            findBranchToolStripMenuItem.Enabled = false;

            notificationLabel.Text = "Seniausius automobilius turintis filialas rastas!\n";
        }

        /// <summary>
        /// Actions of the "Didžiausio kiekio radimas" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findLargestCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetBothBranchTransportation(transportList, finalList);
            GetBothBranchTransportation(secondTransportList, finalList);

            transportCount = FindAllTransport(finalList);
            mostFrequentManufacturers = FindMostFrequentManufacturer(transportCount);

            PrintTransport(CFr, mostFrequentManufacturers);

            string resultFile = File.ReadAllText(CFr);
            results.Text = resultFile;
            findLargestCountToolStripMenuItem.Enabled = false;

            notificationLabel.Text = "Daugiausiai automobilių turintis gamintojas ir tų " +
                "automobilių kiekis rastas!\n";
        }

        /// <summary>
        /// Actions of the "Naujo sąrašo formatavimas" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formattingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gas == "hibridas")
                FormatNewList(finalList, theLastList, typeof(Car), gas);
            else if(gas == "dyzelinis")
                FormatNewList(finalList, theLastList, typeof(Lorry), gas);
            else if(gas == "elektrinis")
                FormatNewList(finalList, theLastList, typeof(Bus), gas);
            else
                using (var fr = new StreamWriter(File.Open(CFr, FileMode.Append)))
                {
                    fr.WriteLine("Klaidngai įvestas kuro tipas!");
                }

            PrintTransportList(CFr, theLastList, "Naujai suformuotas sąrašas", "");

            string resultFile = File.ReadAllText(CFr);
            results.Text = resultFile;
            formattingToolStripMenuItem.Enabled = false;

            notificationLabel.Text = "Naujas sąrašas sudarytas!\n";
        }

        /// <summary>
        /// Actions of the "Rikiavimas" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sorting(theLastList);
            PrintTransportList(CFr, theLastList, "Surikiuotas sąrašas", "");

            string resultFile = File.ReadAllText(CFr);
            results.Text = resultFile;
            sortToolStripMenuItem.Enabled = false;

            notificationLabel.Text = "Sąrašas buvo surikiuotas!\n";

        }

        /// <summary>
        /// Actions of the "Informacija" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programos versija: 17.5.3\n" +
                            "Programos sukūrimo data: 2023 balandis\n" +
                            "Programos autorius: MD",
                            "Informacija apie programą");
        }

        //===================================================================
        // USER METHODS
        //===================================================================

        /// <summary>
        /// Reads players data from a file to a list
        /// </summary>
        /// <param name="fn">file name</param>
        /// <param name="transportList">transportation vehicle list</param>
        /// <param name="city">city</param>
        /// <param name="adress">adress</param>
        static void ReadTransportList(string fn, List<Transport> transportList, 
            out string city, out string adress)
        {
            using (StreamReader reader = new StreamReader(fn))
            {
                string line;
                line = reader.ReadLine();
                city = line;
                line = reader.ReadLine();
                adress = line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    char type = char.Parse(parts[0]);

                    if (type == 'c')
                    {
                        Car car = new Car(line);
                        transportList.Add(car);
                    }
                    else if (type == 'l')
                    {
                        Lorry lorry = new Lorry(line);
                        transportList.Add(lorry);
                    }
                    else if (type == 'b')
                    {
                        Bus bus = new Bus(line);
                        transportList.Add(bus);
                    }
                }
            }
        }

        /// <summary>
        /// Prints vehicle data on file
        /// </summary>
        /// <param name="fn">file name</param>
        /// <param name="transportList">transportation vehicle list</param>
        /// <param name="city">city</param>
        /// <param name="adress">adress</param>
        static void PrintTransportList(string fn, List<Transport> transportList, 
            string city, string adress) 
        {
            using (StreamWriter fr = new StreamWriter(File.Open(fn, FileMode.Append)))
            {
                if (transportList.Count > 0)
                {
                    fr.WriteLine(city);
                    fr.WriteLine(adress);
                    fr.WriteLine(new String('-', 150));
                    fr.WriteLine("| {0,16} | {1,10} |   {2,8}   |{3,8} |{4,17} | {5,10} " +
                        "|   {6,9}   |{7,9} | {8, 9} | {9, 9} |",
                                      "Transporto tipas", "Valst. nr.", "Gamintojas", 
                                      "Modelis", 
                                      "Pagaminimo metai", "Tech. apž.", "Kuro tipas", 
                                      "Durų sk.",
                                      "Vietų sk.", "Priekabos tūris");
                    fr.WriteLine(new String('-', 150));

                    for (int i = 0; i < transportList.Count; i++)
                    {
                        fr.WriteLine("{0}", transportList[i].ToString());
                    }
                    fr.WriteLine(new String('-', 150));
                    fr.WriteLine();
                }
                else
                    fr.WriteLine("Tuščias duomenų failas!");
            }
        }

        /// <summary>
        /// Finds the average transportation vehicle age
        /// </summary>
        /// <param name="transportList">transportation vehicle list</param>
        /// <returns>average age</returns>
        static double GetAverageYear(List<Transport> transportList)
        {
            double average = transportList.Average(item => 
            (DateTime.Now.Year - item.yearAndMonthOfManufacture.Year));
            return average;
        }

        /// <summary>
        /// Fills a new list with all the vehicles
        /// </summary>
        /// <param name="transportList">primary transport list</param>
        /// <param name="finalList">final list with all of the vehicles</param>
        static void GetBothBranchTransportation(List<Transport> transportList, 
            List<Transport> finalList)
        {
            foreach (Transport transport in transportList) 
            {
                finalList.Add(transport);
            } 
        }

        /// <summary>
        /// Fills a dictionary without repetetive manufacturer vehicles
        /// </summary>
        /// <param name="finalList">list with all of the vehicles</param>
        /// <returns>dictionary without repeating vehicles</returns>
        static Dictionary<string, int> FindAllTransport(List<Transport> finalList) 
        {
            Dictionary<string, int> transportCount = new Dictionary<string, int>();

            foreach (Transport transport in finalList) 
            {
                string manufacturer = transport.manufacturer;
                if (transportCount.ContainsKey(manufacturer)) 
                {
                    transportCount[manufacturer]++;
                }
                else
                    transportCount.Add(manufacturer, 1);
            }
            return transportCount;
        }

        /// <summary>
        /// A method which finds the most ocurring vehicle brand
        /// </summary>
        /// <param name="transportCount">dictionary with data about vehicles</param>
        /// <returns>a new dictionary</returns>
        static Dictionary<string, int> 
            FindMostFrequentManufacturer(Dictionary<string, int> transportCount) 
        {
            int maxCount = transportCount.Values.Max();
            Dictionary<string, int> mostFrequentManufacturers = 
                new Dictionary<string, int>();
            
            foreach(KeyValuePair<string, int> transport in transportCount)
            {
                if (transport.Value == maxCount) 
                {
                    mostFrequentManufacturers.Add(transport.Key, 
                        transport.Value);
                }
            }
            return mostFrequentManufacturers;
        }

        /// <summary>
        /// A method for printing dictionary data
        /// </summary>
        /// <param name="fn">file name</param>
        /// <param name="transportation">dictionary with vehicles and their counts</param>
        static void PrintTransport(string fn, Dictionary<string, int> transportation) 
        {
            using (StreamWriter fr = new StreamWriter(File.Open(fn, FileMode.Append)))
            {
                foreach (KeyValuePair<string, int> transport in transportation) 
                {
                    fr.WriteLine("Daugiausiai transporto priemonių yra {0} gamintojo, kiekis" +
                        " - {1,2:d}", transport.Key, transport.Value); 
                }
            }
        }

        /// <summary>
        /// A method which formats a new list
        /// </summary>
        /// <param name="transportation">primary list</param>
        /// <param name="finalTransport">final list</param>
        /// <param name="AType">type</param>
        /// <param name="gasType">provided gas type</param>
        static void FormatNewList(List<Transport> transportation, 
            List<Transport> finalTransport, Type AType, string gasType)
        {
            for (int i = 0; i < transportation.Count; i++)
            {
                if (transportation[i].GetType() == AType && 
                    transportation[i].Suitable(transportation[i], gasType) == true)
                    finalTransport.Add(transportation[i]);
            }
        }

        /// <summary>
        /// Bubble sort method
        /// </summary>
        /// <param name="finalTransport">list with vehicles</param>
        static void Sorting(List<Transport> finalTransport)
        {
            bool bk = true;
            int i = 0;
            while (bk)
            {
                bk = false;
                for (int j = finalTransport.Count - 1; j > i; j--)
                {
                    if (finalTransport[j].CompareTo(finalTransport[j - 1]) == -1)
                    {
                        bk = true;
                        Transport X = finalTransport[j - 1];
                        Transport Y = finalTransport[j];
                        finalTransport[j - 1] = Y;
                        finalTransport[j] = X;
                    }
                }
                i++;
            }
        }
        // End USER METHODS
    }
}
