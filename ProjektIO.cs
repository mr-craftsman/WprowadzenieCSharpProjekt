using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        List<Klient> myKlienci = new List<Klient>();
        myKlienci = GetKlientsFromFile();

        List<Klient> KobKlienci = new List<Klient>();
        KobKlienci = myKlienci.Where(x => x.Plec == "K").ToList();

        List<Klient> MenKlienci = new List<Klient>();
        MenKlienci = myKlienci.Where(x => x.Plec == "M").ToList();

        string pracFolder = @"Q:\Users\RAd\Desktop\WSEI\2sem\WproDoPro\CSharp\";

        StreamWriter strWri = new StreamWriter(pracFolder + "kobiety.txt");
        foreach (Klient niewiasta in KobKlienci)
        {
            strWri.WriteLine(niewiasta.Numer +" "+niewiasta.Imie);
        }
        strWri.Close();
        strWri = new StreamWriter(pracFolder + "mezczyzni.txt");
        foreach (Klient mlodzian in MenKlienci)
        {
            strWri.WriteLine(mlodzian.Numer +" "+mlodzian.Imie);
        }
        strWri.Close();
        Console.WriteLine("Wykonano");
    }       

    static public List<Klient> GetKlientsFromFile()
    {       
        List<Klient> myKlienci = new List<Klient>();
        string pracFolder = @"Q:\Users\RAd\Desktop\WSEI\2sem\WproDoPro\CSharp\";
        StreamReader strRea = new StreamReader(pracFolder + "input.txt");
        StreamWriter strWri = new StreamWriter(pracFolder + "output.txt");
        string linia = string.Empty; 
            
        while ((linia = strRea.ReadLine()) != null)
        {
            string[] liniaValue = linia.Split(',');
            Klient myKlient = new Klient();
            myKlient.Numer = liniaValue[0];
            myKlient.Imie = liniaValue[1];
            myKlient.Plec = liniaValue[2];
            myKlienci.Add(myKlient);  
        }
        strRea.Close();
        strWri.Close();  
        return myKlienci;
       
    }
public class Klient
{
    public string Numer;
    public string Imie;
    public string Plec;
}

}
