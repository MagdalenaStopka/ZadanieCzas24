using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    /*
Zadanie - przykład uzycia properties
====================================
Poniżej podany kod zawiera implementację klasy Czas24h w wariancie immutable.
Obiekty tej klasy reprezentują czas w formacie hh:mm:ss.
Obiekty te inicjowane są konstruktorem trójargumentowym Czas24h(hh, mm, ss),
w którym podajemy liczbę godzin, liczbę minut i liczbę sekund.
Wewnętrzna reprezentacja czasu to liczba sekund od 00:00:00.

Zadanie 1.
"Zabezpiecz" konstruktor przed wprowadzeniem niepoprawnych danych 
(zgłoszeniem wyjatku ArgumentException)
Dopuszczalne wartości: 0..59 s, 0..59 min, 0..23 h

Zadanie 2.
Zmodyfikuj klasę Czas24h tak, aby obiekty były 'mutables'.
Zdefiniuj zakomentowane settersy tak, aby po usunięciu komentarza w Main
program wypisał odpowiednie komunikaty.
Settersy dla godziny, minuty oraz sekundy modyfikują jedynie swoją składową 
w reprezentacji godziny. Zabezpiecz je (wyjątkami) przed niepoprawnym wprowadzaniem danych.
Gettersy zostały zaprogramowane, nie możesz ich zmieniać.
 */
    using System;

    public class Program
    {
        public static void Main()
        {

            Czas24h2 t = new Czas24h2(0, 20, 9);
            Console.WriteLine(t); //wypisze 2h 15min 37s
                                  /*
                                      t.Minuta = 20; //brak set
                                      Console.WriteLine( t ); //wypisze 2h 20min 37s
                                      t.Godzina = 1; //brak set
                                      Console.WriteLine( t ); //wypisze 1h 20min 37s
                                      t.sekunda = 26; //brak set
                                      Console.WriteLine( t ); //wypisze 1h 20min 26s
                                  */

            t.Minuta = 7;
            t.Godzina = 8;
            t.Sekunda = 7;
            Console.WriteLine(t);

            Console.ReadKey();
        }
    }


    class Czas24h2
    {

        private int liczbaSekund;
        private byte _Minuta;
        public byte _Sekunda;
        public byte _Godzina;

        public byte Minuta
        {
            get
            {
                return _Minuta;
            }
            set
            {
                if (value >= 0 && value <= 59)
                    _Minuta = value;
                else
                    throw new ArgumentException("Podano błędną wartość");
            }

        }

        public byte Godzina
        {
            get
            {
                return _Godzina;
               
            }
            set
            {


                if (value >= 0 && value <= 59)
                    _Godzina = value;
                else
                    throw new ArgumentException("Podano błędną wartość");
            }
        }

        public byte Sekunda
        {
            get
            {
                return _Sekunda;
               
            }
            set
            {


                if (value >= 0 && value <= 59)
                    _Sekunda = value;
                else
                    throw new ArgumentException("Podano błędną wartość");
               
            }
        }

        public Czas24h2(byte godzina, byte minuta, byte sekunda)
        {

            if ((sekunda < 59 && sekunda > 0) && (minuta < 59 && minuta >= 0) && (godzina < 24 && godzina >= 0))
            {
                liczbaSekund = sekunda + 60 * minuta + 3600 * godzina;
                _Minuta = minuta;
                _Sekunda = sekunda;
                _Godzina = godzina;
            }
            else
                throw new ArgumentException("Podana liczba w przypadku sekund i minut musi byc w zakresie od 0 do 59, a w przypadku godzin od 0 do 23");
        }


        public override string ToString()
        {
            return _Godzina + "h " + _Minuta + "min " + _Sekunda + "s";
        }
    }
}

