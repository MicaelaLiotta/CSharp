using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp3_programacion_ej4
{
    public static class Biblioteca
    {
        public static List<Libro> libros = new List<Libro>();
        public static List<Prestamo> prestamos = new List<Prestamo>();

        public static void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
            Console.WriteLine("Libro agregado exitosamente.");

        }

        public static Libro BuscarPorISBN(string isbn)
        {
            Console.WriteLine("Ingrese el isbn del libro que desea buscar: ");
            string isbnBuscar = Console.ReadLine();

            foreach (Libro libro in libros)
            {
                if (libro.ISBN == isbnBuscar)
                {
                    Console.WriteLine($"Libro encontrado: {libro.Titulo}, {libro.Autor}, {libro.Genero}");
                    return libro;
                }
            }
            Console.WriteLine("Libro no encontrado.");
            return null;
        }

        public static void PrestarLibro(string isbn, string lector, DateTime fechaPrestamo)
        {
            foreach (Libro libro in libros)
            {
                if (libro.ISBN == isbn && libro.NumEjemplaresDisponibles > 0)
                {
                    libro.NumEjemplaresDisponibles--;
                    prestamos.Add(new Prestamo
                    {
                        FechaPrestamo = fechaPrestamo,
                        LibroPrestado = libro,
                        Lector = lector
                    });
                    
                    Console.WriteLine("Libro prestado exitosamente.");
                }
            }
        }

        public static void DevolverLibro(string isbn)
        {
            foreach (Prestamo prestamo in prestamos)
            {
                if (prestamo.LibroPrestado.ISBN == isbn)
                {
                    prestamo.LibroPrestado.NumEjemplaresDisponibles++;
                    prestamo.FechaDevolucion = DateTime.Now;
                    prestamos.Remove(prestamo);
                    Console.WriteLine("Libro devuelto exitosamente. Fecha de devolución: " + prestamo.FechaDevolucion);
                    break; 
                }
            }
        }

        public static void MostrarLibrosDisponibles()
        {
            Console.WriteLine("Lista de libros disponibles:");
            foreach (Libro libro in libros)
            {
                Console.WriteLine($"Título: {libro.Titulo}, Autor: {libro.Autor}, ISBN: {libro.ISBN}, Ejemplares Disponibles: {libro.NumEjemplaresDisponibles}");
            }
        }

        public static List<Libro> MostrarLibrosPrestados()
        {
            List<Libro> librosPrestados = new List<Libro>();
            foreach (Prestamo prestamo in prestamos)
            {
                librosPrestados.Add(prestamo.LibroPrestado);
            }
            return librosPrestados;
        }

        
    }
}
