using System;
// using System.Collections.Generic;                       // Zbog LinkedList
class R2_T03_05_Red_Kruzna_lista_Niz
{
    static void Main()
    {
        string s = Console.ReadLine();                  // ULAZ: uuussuusis
        int n = s.Length;                               // n: Duzina ulaznog stringa: 10
        int[] a = new int[n];                           // a: Niz (Kolo)
        int b = 0;                                      // b: Broj igraca u kolu: b = a.Count;
        int v = 0;                                      // p: Pozicija vodje (sesira) u kolu
        for (int i = 0; i < n; i++)
        {
            char c = s[i];
            if (c == 'u')                               // Dodavanje novog igraca u kolo koji odmah postaje vodja
            {
                b++;                                    // Inkrementiramo ukupan broj igraca u kolu
                for (int p = b - 1; p > v; p--)         // Pomeramo sve igrace koji su iza vodje za jedno mesto udesno, kako bi napravili mesto za novog igraca
                    a[p] = a[p - 1];
                a[v] = b;                               // Nov igrac se dodaje u kolo ispred onog koji ima sesir i uzima sesir od njega (postaje vodja i uzima sesir)
            }
            else if (c == 's')                          // Predavanje sesira narednom igracu (ispred sebe, odnosno poslednjem u kolu)
            {
                v = (v == 0) ? b - 1 : v - 1;           // Pomeramo poziciju vodje za 1 mesto ispred (ulevo)
            }
            else if (c == 'i')                          // Izbacicanje vodje iz kola
            {
                if (b > 0) b--;                         // Dekrementiramo ukupan broj igraca u kolu (za potencijalno sledeceg novog igraca)
                for (int p = v; p < b; p++)             // Pomeramo sve igrace koji su iza vodje za jedno mesto ulevo
                    a[p] = a[p + 1];
                a[b] = -1;                              // Oznacavamo da iza pozicije b nema vise igraca u kolu (nije neophodno, ali moze da bude korisno)
                if (v == b) v = 0;                      // Ako je vodja bio na kraju (desno) kolekcije
            }
        }

        // IZLAZ:                                       // 1 2 4 5
        if (b > 0)                                      // Ako ima igraca u kolu
        {
            for (int i = v; i >= 0; i--)                // Ispisujemo brojeve svih igraca od vodje i ispred vodje ulevo redom
                Console.Write(a[i] + " ");
            for (int i = b - 1; i > v; i--)             // Ispisujemo brojeve svih igraca iza vodje pocev od kraja niza ulevo do vodje
                Console.Write(a[i] + " ");
        }
        Console.WriteLine();
    }
}

// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka2/kruzna_lista
// https://github.com/draganilicnis/R2_T03_06_Red_Kruzna_lista
