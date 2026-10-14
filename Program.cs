using System.Text;

namespace ENCRIPTACION
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? ruta = " ", rutaGuardado = " ", contraseña = " ";
            Console.WriteLine("Dime la ruta (copiada) del archivo: ");
            ruta = Vacio(ruta);
            Console.WriteLine("Dime la ruta donde quieres guardar el nuevo archivo: ");
            rutaGuardado = Vacio(rutaGuardado);
            Console.WriteLine("Dime la contraseña de Encriptación: ");
            contraseña = Vacio(contraseña);
            try
            {
                XOR(ruta, rutaGuardado, contraseña);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("❌ El archivo no existe.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("❌ La carpeta no existe.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("❌ No tienes permisos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }
        static void XOR(string ruta, string rutaGuardado, string claveString)
        {
            byte[] clave = Encoding.UTF8.GetBytes(claveString);
            byte[] bytes = File.ReadAllBytes(ruta);
            byte[] bytesEncriptados = new byte[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytesEncriptados[i] = (byte)(bytes[i] ^ clave[i % clave.Length]);
            }
            File.WriteAllBytes(rutaGuardado, bytesEncriptados);
        }
        public static string Vacio(string? input)
        {
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) Console.WriteLine("Escribe algo: ");
                else return input.Trim('"');
            } while (true);
        }
    }
}
