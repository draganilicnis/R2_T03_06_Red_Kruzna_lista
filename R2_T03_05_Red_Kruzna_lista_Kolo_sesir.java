import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String s = sc.next();

        Deque<Integer> a = new ArrayDeque<>();

        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);

            if (c == 'u') {                     // dodavanje na pocetak
                a.addFirst(a.size() + 1);
            }
            else if (c == 'i' && !a.isEmpty()) { // izbacivanje prvog
                a.removeFirst();
            }
            else if (c == 's' && !a.isEmpty()) { // poslednji ide na pocetak
                int ispred_v = a.removeLast();
                a.addFirst(ispred_v);
            }
        }

        // priprema za stampu (prvi ide na kraj)
        if (!a.isEmpty()) {
            int v = a.removeFirst();
            a.addLast(v);
        }

        // stampanje (kao u originalu)
        while (!a.isEmpty()) {
            System.out.print(a.removeLast() + " ");
        }

        sc.close();
    }
}