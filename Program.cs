using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace EntrevistaJuniorNET
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public bool Activo { get; set; }
    }

    public interface IPago
    {
        void procesarPago(decimal monto);
    }

    public class PagoTarjeta : IPago{
        public void procesarPago(decimal monto){
            Console.WriteLine("Procesando pago de " + monto + " con tarjeta");
        }
    }

    public class PagoPayPal : IPago{

        public void procesarPago(decimal monto){
            Console.WriteLine("Procesando pago de " + monto + " con paypal");
        }

    }


    public class PagoCripto : IPago{

        public void procesarPago(decimal monto){
            Console.WriteLine("Procesando pago de " + monto + " con cripto");
        }
    }

    public static class StringExtensions{
        public static bool EsPalindromo(this string palabra){
            string textoLimpio = palabra.ToLower();
            string palabraInvertida = string.Concat(textoLimpio.Reverse());

            return textoLimpio == palabraInvertida;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //ejercicio1();

/*             List<IPago> pagos = new List<IPago>
            {
                new PagoTarjeta(),
                new PagoPayPal(),
                new PagoCripto()
            };

            Console.WriteLine("Iniciando procesamiento de pagos...\n");

            // El foreach recorre la lista sin importar qué tipo específico de pago es
            foreach (var pago in pagos)
            {
                pago.procesarPago(1500.50m);
            } */

 /*            string textoPrueba = "Hola Analista Universitario";
            Console.WriteLine($"Contando caracteres para: '{textoPrueba}'\n");

            // Llamada al método que vas a crear
            Dictionary<char, int> resultado = ContarCaracteres(textoPrueba);

            // Bucle para imprimir tu resultado
            if (resultado != null)
            {
                foreach (var par in resultado)
                {
                    Console.WriteLine($"Carácter '{par.Key}': {par.Value} veces");
                }
            } */
            
/*           Console.WriteLine("Iniciando consultas a bases de datos...\n");

            // Stopwatch nos sirve para medir cuánto tiempo tarda el código en ejecutarse
            Stopwatch cronometro = Stopwatch.StartNew();

            // Llamamos a tu método
            await EjecutarConsultasAsync();

            cronometro.Stop();
            Console.WriteLine($"\nTiempo total de ejecución: {cronometro.Elapsed.TotalSeconds:F1} segundos");
            // ¡EL OBJETIVO ES QUE EL TIEMPO TOTAL SEA ~3.0 SEGUNDOS! */

/*             ejercicio3();

            Console.WriteLine("Probando método de extensión EsPalindromo...\n");

            string palabra1 = "radar";
            string palabra2 = "desarrollador";
            string palabra3 = "Neuquen"; // Ojo con las mayúsculas al resolver tu lógica

            // ==========================================
            // TODO 2: DESCOMENTA ESTO CUANDO TU MÉTODO ESTé LISTO
            // ==========================================
            

            Console.WriteLine($"¿'{palabra1}' es palíndromo? {palabra1.EsPalindromo()}"); // Debería dar True
            Console.WriteLine($"¿'{palabra2}' es palíndromo? {palabra2.EsPalindromo()}"); // Debería dar False
            Console.WriteLine($"¿'{palabra3}' es palíndromo? {palabra3.EsPalindromo()}"); // Debería dar True (ignorando mayúsculas)
         
 */
/*             Console.WriteLine("Iniciando sistema de registro...\n");

            try{
            RegistrarUsusario(15);
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\nEl programa terminó correctamente (no explotó)."); */

/*             Console.WriteLine("Iniciando compresión de cadenas...\n");

            string textoPrueba1 = "aaabbc";      // Esperado: a3b2c1
            string textoPrueba2 = "zzzzzz";      // Esperado: z6
            string textoPrueba3 = "a";           // Esperado: a1
            
            // ==========================================
            // TODO 2: DESCOMENTA ESTAS LÍNEAS PARA PROBAR
            // ==========================================
           
            Console.WriteLine($"Original: {textoPrueba1} -> Comprimido: {ComprimirCadena(textoPrueba1)}");
            Console.WriteLine($"Original: {textoPrueba2} -> Comprimido: {ComprimirCadena(textoPrueba2)}");
            Console.WriteLine($"Original: {textoPrueba3} -> Comprimido: {ComprimirCadena(textoPrueba3)}"); */

            Console.WriteLine("Iniciando Cifrado...\n");

            string texto = "xyz";
            int posicionesACorrer = 3;

            Console.WriteLine($"Original: {texto}");
            // Si corres 'xyz' 3 posiciones, la 'x' se vuelve 'a', 
            // la 'y' se vuelve 'b' y la 'z' se vuelve 'c'.
            Console.WriteLine($"Cifrado:  {CifrarTexto(texto, posicionesACorrer)}");

        }

        static void ejercicio1(){
              List<Empleado> empleados = new List<Empleado>
            {
                new Empleado { Id = 1, Nombre = "Ana", Departamento = "IT", Salario = 1600m, Activo = true },
                new Empleado { Id = 2, Nombre = "Carlos", Departamento = "Ventas", Salario = 1200m, Activo = true },
                new Empleado { Id = 3, Nombre = "Beatriz", Departamento = "IT", Salario = 1800m, Activo = true },
                new Empleado { Id = 4, Nombre = "David", Departamento = "IT", Salario = 1400m, Activo = true }, // Falla por salario
                new Empleado { Id = 5, Nombre = "Elena", Departamento = "IT", Salario = 2000m, Activo = false }, // Falla por inactiva
                new Empleado { Id = 6, Nombre = "Zack", Departamento = "IT", Salario = 2100m, Activo = true }
            };

            Console.WriteLine("Ejecutando consulta LINQ...");

            IEnumerable<string> resultado = from e in empleados 
                                             where e.Salario > 1500 && e.Activo == true && e.Departamento == "IT"
                                             orderby e.Nombre descending
                                             select e.Nombre;

            foreach (var nombre in resultado)
            {
                Console.WriteLine(nombre);
            }
        }

        static Dictionary<char, int> ContarCaracteres(string texto){
            Dictionary<char, int> diccionario = new Dictionary<char, int>();
            
            string textoLimpio =  texto.ToLower();

            foreach(char letra in textoLimpio){
                if(letra == ' ') continue;
                if(diccionario.ContainsKey(letra)){
                    diccionario[letra]++;
                }else{
                    diccionario[letra] = 1;
                }
            }
            return diccionario;
        }

        static async Task EjecutarConsultasAsync(){

            Task<string> tarea1 = ConsultaBaseDatos1Async();
            Task<string> tarea2 = ConsultaBaseDatos2Async();

            await Task.WhenAll(tarea1, tarea2); 

        }

        static async Task<string> ConsultaBaseDatos1Async()
        {
            Console.WriteLine("Iniciando DB 1 (tardará 2 segundos)...");
            await Task.Delay(2000); 
            Console.WriteLine("DB 1 terminada.");
            return "Resultado DB 1";
        }

        static async Task<string> ConsultaBaseDatos2Async()
        {
            Console.WriteLine("Iniciando DB 2 (tardará 3 segundos)...");
            await Task.Delay(3000);
            Console.WriteLine("DB 2 terminada.");
            return "Resultado DB 2";
        }

     static void ejercicio3(){
              List<Empleado> empleados = new List<Empleado>
            {
                new Empleado { Id = 1, Nombre = "Ana", Departamento = "IT", Salario = 1600m, Activo = true },
                new Empleado { Id = 2, Nombre = "Carlos", Departamento = "Ventas", Salario = 1200m, Activo = true },
                new Empleado { Id = 3, Nombre = "Beatriz", Departamento = "IT", Salario = 1800m, Activo = true },
                new Empleado { Id = 4, Nombre = "David", Departamento = "IT", Salario = 1400m, Activo = true }, // Falla por salario
                new Empleado { Id = 5, Nombre = "Elena", Departamento = "IT", Salario = 2000m, Activo = false }, // Falla por inactiva
                new Empleado { Id = 6, Nombre = "Zack", Departamento = "IT", Salario = 2100m, Activo = true }
            };

            Console.WriteLine("Ejecutando consulta LINQ...");

            IEnumerable<(string Departamento, int Cantidad)> resultado = from e in empleados
                                              group e by e.Departamento into groupEmpleados
                                              select (
                                                Departamento : groupEmpleados.Key,
                                                Cantidad : groupEmpleados.Count()
                                              );
                                                

            foreach (var item in resultado)
            {
                Console.WriteLine(item.Departamento + " " + item.Cantidad);
            }
        }

        static void RegistrarUsusario(int edad){
            if(edad < 18){
                throw new Exception("El usuario debe ser mayor de 18");
            }else{
                Console.WriteLine("Usuario registrado exitosamente");
            }
        }

        static string ComprimirCadena(string cadena){
            
            if(string.IsNullOrEmpty(cadena)) return "";

            string resultado = "";
            int contador = 1;
            char[] caracteres = cadena.ToCharArray();


            for(int i = 0; i < caracteres.Length; i++){

                if(i+1 < caracteres.Length && caracteres[i] == caracteres[i + 1]){
                    contador++;
                }else{
                    resultado += caracteres[i];
                    resultado += contador.ToString();
                    contador = 1;
                }
            }

            return resultado;

        }

        static string CifrarTexto(string texto, int desplazamiento){

            string alfabeto = "abcdefghijklmnopqrstuvwxyz";
            string resultado = "";

            foreach(char letras in texto){
                    int index = alfabeto.IndexOf(letras);
                    int posicion = (index + desplazamiento) % 26;
                    resultado += alfabeto[posicion];
            }

            return resultado;
        }
    }
}