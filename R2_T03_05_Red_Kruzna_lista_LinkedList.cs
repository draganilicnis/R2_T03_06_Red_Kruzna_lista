using System;
using System.Collections.Generic;               // Zbog LinkedList
class R2_T03_05_Red_Kruzna_lista
{
    static void Main()
    {
        string s = Console.ReadLine();          // ULAZ: uuussuusis
        var a = new LinkedList<int>();          // LinkedList
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];  
            if (c == 'u')                       // Dodavanje novog igraca: Nov igrac se dodaje na prvo mesto u kolo ispred vodje i postaje vodja 
                a.AddFirst(a.Count + 1);                
            else if (c == 'i' && a.Count > 0)   // Izbacivanje vodje iz kola (prvog elementa). Vodja je igracu iza starog (koji je bio na 2. poziciji)
                a.RemoveFirst();                    
            else if (c == 's' && a.Count > 0)   // Predavanje sesira narednom igracu (ispred sebe, odnosno poslednjem u kolu)
            {
                int ispred_v = a.Last.Value;    // Uzimamo vrednost igraca koji je ispred vodje (posledenjeg u listi)
                a.RemoveLast();                 // Izbacujemo poslednji element iz kola
                a.AddFirst(ispred_v);           // Dodajemo na prvo mesto (kao vodju) igraca koji je bio poslednji u kolu (i uzima sesir)
            }
        }

        // Prirema za stampanje podataka
        int v = a.First.Value;                  // Uzimamo vrednost vodje (da bi ga prebacili na kraj liste)
        a.RemoveFirst();                        // Izbacujemo vodju sa pocetka linkovane liste
        a.AddLast(v);                           // Dodajemo vodju na kraj linkovane liste
        
        // IZLAZ
        while (a.Count > 0)                     // Sve dok ima elemenata u linkovanoj listi (igraca u kolu)
        {
            Console.Write(a.Last.Value + " ");  // Stampamo vrednost poslednjeg elementa iz linkovane liste (FIFO) : 1 2 4 5
            a.RemoveLast();                     // Izbacujemo poslednji element iz linkovane liste
        }
    }
}

// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka2/kruzna_lista
// https://github.com/draganilicnis/R2_T03_06_Red_Kruzna_lista
