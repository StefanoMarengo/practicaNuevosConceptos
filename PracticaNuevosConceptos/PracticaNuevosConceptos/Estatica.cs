using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Practicasss
{
    public static class Estatica
    {
//        Crear un método de extensión que reciba un string y retorne la cantidad de palabras.
        public static int CantidadPalabras(this string cadena)
        {
            string[] array = cadena.Split(' ');
            return array.Count();
        }
//Crear una sobreescritura del método 1 para que reciba un parámetro adicional char con el separador a usar para contar las palabras.
        public static int CantidadPalabras(this string cadena, char separator)
        {
            string[] array = cadena.Split(separator);
            return array.Count();
        }
//Cree un método de extensión que reciba dos fechas DateTime y calcule su diferencia en segundos
//y que retorne un decimal con su formato en minutos (en valor decimal, es de 120 = 2 o 180 = 2,5)
        public static decimal RetornarMinutos(this DateTime fecha1, DateTime fecha2)
        {
            return (int)(fecha1 - fecha2).TotalSeconds / 60;
        }
        //Crear un método de extensión que reciba una lista de enteros y devuelva su promedio.
        public static double ObtenerPromedio(this List<int> listaEnteros)
        {
            return listaEnteros.Sum()/listaEnteros.Count;
        }

        //5) Crear un método de extensión que reciba una lista de enteros y devuelva 
        //      la suma de los valores pares * la resta de los impares.
        public static int DevolverResultado(this List<int> listax)
        {
            List<int> Pares=listax.Where(x => (x % 2) == 0).ToList();
            List<int> Impares=listax.Where(x => (x % 2) != 0).ToList();

            return Pares.Sum() * Impares.Sum(x=>-x);
        }
        //6) Crear un método de extensión que retorne una fecha en formato DateTime a partir de un string
        //(si se genera una excepción por mal formato retornar el MinValue del tipo de datos).
        public static DateTime TraducirAFecha(this string stringFecha)
        {
            DateTime fechaParseada = DateTime.Now;
            try
            {
                fechaParseada = DateTime.Parse(stringFecha);
            }
            catch(Exception ex) //No Sé
            {
                return DateTime.MinValue;
            }
            return fechaParseada;
        }
        //7) Crear un método de extensión que dado un string, retorne otro invertido.
        public static string Invertir(this string cadena)
        {
            char[] charArray = cadena.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        //8) Crear un método de extensión que dado un array de strings, genere un solo string separado por un parámetro de tipo char.
        public static string ArmarString(this char[] charArray, char separador)
        {
            return (new string(charArray).Split(separador)).ToString();
        }
        //9) Crear un método de extensión que reciba un string y retorne un valor booleano que indique si es un correo electrónico o no
        public static bool EsCorreo(string cadena)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase); //using System.Text.RegularExpressions;
            return regex.IsMatch(cadena);
        }
        //10) Crear un método de extensión que reciba un string y retorne un valor booleano que indique si es un CUIT o no (investigar Regex).
        public static bool EsCUIT(string cadena)
        {
            Regex regex = new Regex("^(20|2[3-7]|30|3[3-4])*-(\\d{8})*-(\\d{2})$", RegexOptions.IgnoreCase);
            return regex.IsMatch(cadena);
        }
        //11) Cree dos instancias de tipo “cliente” (nombre, cuit, saldo). Sobrecargue el operador de resta para que:
        //si los cuits son iguales: que retorne un cliente con saldo = resta de los dos saldos.
        //si son distintos: retorne un cliente con saldo = saldo menor de los dos clientes.
        public class Cliente
        {
            public string Nombre { get; set; }
            public string CUIT { get; set; }
            public int Saldo { get; set; }
            public Cliente(int saldo)
            {
                Saldo = saldo;
            }
        }
        public static Cliente Restar(Cliente cliente1, Cliente cliente2)
        {
            if (cliente1.CUIT == cliente2.CUIT)
                return new Cliente(cliente1.Saldo - cliente2.Saldo);
            else
                return new Cliente(cliente1.Saldo <= cliente2.Saldo ? cliente1.Saldo : cliente2.Saldo);
        }
        //12) Crear una clase estática que contenga dos métodos que convierten la temperatura de grados Celsius a grados Fahrenheit
        //y viceversa (f = c * 2.12; c = f / 2.12).
        public static class Convertidor
        {
            public static double CelsiusAFahrenheit(int c)
            {
                return c * 2.12;
            }
            public static double FahrenheitACelsius(int f)
            {
                return f / 2.12;
            }
        }
        //13) Crear un método de extensión que reste dos números enteros.
        public static int Restar(this int nro1, int nro2)
        {
            return nro1 - nro2;
        }

        //14) Sobreescribir el operador / de dos números enteros para que retorne el valor decimal.
        public static decimal Dividir(this int nro1, int nro2)
        {
            decimal resultado = nro1 / nro2;
            return resultado - Math.Truncate(resultado); 
        }

        //15) Cree una clase estática “Rectangulo” que tenga dos métodos estáticos que permitan calcular perímetro y área.
        public static class Rectangulo
        {
            public static int LadoA { get; set; }
            public static int LadoB { get; set; }
            public static int getPerimetro()
            {
                return (LadoA + LadoB) * 2;
            }
            public static int getArea()
            {
                return LadoA * LadoB;
            }

        }
    }
}
