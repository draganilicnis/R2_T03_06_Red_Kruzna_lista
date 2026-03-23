#include <iostream>
#include <list>
#include <deque>
#include <string>
using namespace std;

int main()
{
    string s;
    cin >> s;                      // ULAZ: uuussuusis

    deque<int> a;                   // ekvivalent LinkedList<int>

    for (int i = 0; i < s.length(); i++)
    {
        char c = s[i];

        if (c == 'u')              // dodavanje novog igraca na pocetak
            a.push_front(a.size() + 1);
        else if (c == 'i' && !a.empty())   // izbacivanje prvog
            a.pop_front();
        else if (c == 's' && !a.empty())   // rotacija (poslednji ide na pocetak)
        {
            int ispred_v = a.back();  // poslednji
            a.pop_back();
            a.push_front(ispred_v);
        }
    }
    // priprema za stampu
    if (!a.empty())
    {
        int v = a.front();
        a.pop_front();
        a.push_back(v);
    }
    // IZLAZ: 1 2 4 5
    while (!a.empty())
    {
        cout << a.back() << " ";
        a.pop_back();
    }

    return 0;
}
