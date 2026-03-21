using System;
using System.Collections.Generic;                       // Zbog LinkedList
class R2_T03_05_Red_Kruzna_lista
{
    static void Main()
    {
        string s = Console.ReadLine();                  // ULAZ: uuussuusis
        var a = new LinkedList<int>();                  // LinkedList
        int b = 1;                                      // Broj (prvog slececeg) igraca u kolu: b = a.Count + 1;
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == 'u')                               // Dodavanje novog igraca u kolo koji odmah postaje vodja
            {
                a.AddFirst(b);                          // Nov igrac se dodaje na prvo mesto u kolo ispred onog koji ima sesir i uzima sesir od njega (postaje vodja i uzima sesir)
                b++;                                    // Inkrementiramo ukupan broj igraca u kolu (za potencijalno sledeceg novog igraca)
            }
            else if (c == 's')                          // Predavanje sesira narednom igracu (ispred sebe, odnosno poslednjem u kolu)
            {
                if (a.Count > 0)
                {
                    int poslednji = a.Last.Value;       // Uzimamo vrednost poslednjeg igraca u kolu
                    a.RemoveLast();                     // Izbacujemo poslednji element iz kola
                    a.AddFirst(poslednji);              // Dodajemo na prvo mesto (kao vodju) igraca koji je bio poslednji u kolu (i uzima sesir)
                }
            }
            else if (c == 'i')                          // Izbacicanje vodje iz kola
            {
                if (a.Count > 0)
                {
                    a.RemoveFirst();                    // Izbacujemo prvi element (vodju iz kola). Sesir predaje igracu iza sebe (koji je bio na 2. poziciji)
                    b--;                                // Dekrementiramo ukupan broj igraca u kolu (za potencijalno sledeceg novog igraca)
                }
            }
        }

        int vodja = a.First.Value;                      // Prebacujemo vodju na kraj linkovane liste: Uzimamo vrednost vodje sa
        a.RemoveFirst();                                // Izbacujemo vodju sa pocetka linkovane liste
        a.AddLast(vodja);                               // Dodajemo vodju na kraj linkovane liste

        while (a.Count > 0)                             // Sve dok ima elemenata u linkovanoj listi (igraca u kolu)
        {
            Console.Write(a.Last.Value + " ");          // Stampamo vrednost poslednjeg elementa iz linkovane liste (FIFO)
            a.RemoveLast();                             // Izbacujemo poslednji element iz linkovane liste
        }
    }
}

// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka2/kruzna_lista
// https://github.com/draganilicnis/R2_T03_06_Red_Kruzna_lista
