namespace tp3_programacion_ej4
{
    internal class Program
    {
         static void Main(string[] args)
        {
            

            MostrarMenu();
        }

        static void MostrarMenu()
        {
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Agregar un nuevo libro.");
            Console.WriteLine("2. Buscar un libro por ISBN.");
            Console.WriteLine("3. Prestar un libro.");
            Console.WriteLine("4. Devolver un libro.");
            Console.WriteLine("5. Mostrar la lista de libros disponibles.");
            Console.WriteLine("6. Mostrar la lista de libros prestados.");
            Console.WriteLine("7. Salir.");
            Console.WriteLine("Ingrese el número de la opción que desea realizar:");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Opción 1: Agregar un nuevo libro.");
                    Libro nuevoLibro = new Libro();
                    

                    Console.WriteLine("Ingrese el título del libro:");
                    nuevoLibro.Titulo = Console.ReadLine();

                    Console.WriteLine("Ingrese el autor del libro:");
                    nuevoLibro.Autor = Console.ReadLine();

                    Console.WriteLine("Ingrese el ISBN del libro:");
                    nuevoLibro.ISBN = Console.ReadLine();

                    Console.WriteLine("Ingrese el género del libro:");
                    nuevoLibro.Genero = Console.ReadLine();

                    Console.WriteLine("Ingrese el número de ejemplares disponibles:");
                    nuevoLibro.NumEjemplaresDisponibles = int.Parse(Console.ReadLine());

                    Biblioteca.AgregarLibro(nuevoLibro);
                    break;

                case "2":
                    Console.WriteLine("Opción 2: Buscar un libro por ISBN.");
                    Console.WriteLine("Ingrese el ISBN del libro que desea buscar:");
                    string isbnBuscar = Console.ReadLine();
                    Biblioteca.BuscarPorISBN(isbnBuscar);
                    break;

                case "3":
                    Console.WriteLine("Opción 3: Prestar un libro.");
                    Console.WriteLine("Ingrese el ISBN del libro que desea prestar:");
                    string isbnPrestar = Console.ReadLine();
                    Console.WriteLine("Ingrese el nombre del lector:");
                    string lectorPrestar = Console.ReadLine();
                    Console.WriteLine("Ingrese la fecha de préstamo (yyyy-mm-dd):");
                    DateTime fechaPrestamo = DateTime.Parse(Console.ReadLine());
                    Biblioteca.PrestarLibro(isbnPrestar, lectorPrestar, fechaPrestamo);
                    break;

                case "4":
                    Console.WriteLine("Opción 4: Devolver un libro.");
                    Console.WriteLine("Ingrese el ISBN del libro que desea devolver:");
                    string isbnDevolver = Console.ReadLine();
                    Biblioteca.DevolverLibro(isbnDevolver);
                    break;

                case "5":
                    Console.WriteLine("Opción 5: Mostrar la lista de libros disponibles.");
                    Biblioteca.MostrarLibrosDisponibles();
                    break;

                case "6":
                    Console.WriteLine("Opción 6: Mostrar la lista de libros prestados.");
                    var librosPrestados = Biblioteca.MostrarLibrosPrestados();
                    if (librosPrestados.Count > 0)
                    {
                        Console.WriteLine("Lista de libros prestados:");
                        foreach (var libro in librosPrestados)
                        {
                            Console.WriteLine($"Título: {libro.Titulo}, Autor: {libro.Autor}, ISBN: {libro.ISBN}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay libros prestados en este momento.");
                    }
                    break;

                case "7":
                    Console.WriteLine("Saliendo del programa...");
                    return; 
                default:
                    Console.WriteLine("Opción no válida. Por favor, ingrese un número válido.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();                                      //lee una tecla
            Console.Clear();                                       // Limpiar la consola para mostrar el menú nuevamente
            MostrarMenu(); 
        }
    }
}