#include <iostream>
#include <list>
#include <string>
using namespace std;
int main()
{
    string s;
    cin >> s;                      // ULAZ: uuussuusis
    list<int> a;                   // ekvivalent LinkedList<int>
    for (int i = 0; i < s.length(); i++)
    {
        char c = s[i];
        if (c == 'u') a.push_front(a.size() + 1); // dodavanje novog igraca na pocetak
        else if (c == 'i' && !a.empty()) a.pop_front();// izbacivanje prvog
        else if (c == 's' && !a.empty())   // rotacija (poslednji ide na pocetak)
        {
            int ispred_v = a.back();  // poslednji
            a.pop_back();
            a.push_front(ispred_v);
        }
    }
    if (!a.empty())
    {
        int v = a.front();
        a.pop_front();
        a.push_back(v);
    }
    while (!a.empty())
    {
        cout << a.back() << " ";
        a.pop_back();
    }
    return 0;
}