using System;

namespace Napster
{
    class Program
    {
        static void Main(string[] args)
        {
            Service.Genres serviceGenre = new Service.Genres();
            Service.Albums serviceAlbum = new Service.Albums();

            Console.WriteLine("Aqui podras ejecutar los servicios que buscaran informacion en la pagina de 'napster'.");
            Console.WriteLine("*------------------------------------------------------------------------------------*");
            Console.WriteLine("");
            Console.WriteLine("    Cuando los servicios hayan finalizado la informacion estara en la base de datos,");
            Console.WriteLine("    y podra ser leida atraves del proyecto 'WebApi'");
            Console.WriteLine("");

            Console.WriteLine(" Buscando artistas y generos musicales...");
            serviceGenre.SearchGenres("https://us.napster.com/music");
            Console.WriteLine(" Proceso terminado.");
            Console.WriteLine("");
            Console.WriteLine(" Buscando subgeneros...");
            serviceGenre.SearcSubsGenres("https://us.napster.com/genre");
            Console.WriteLine(" Proceso terminado.");
            Console.WriteLine("");

            Console.WriteLine(" Buscando albums y canciones.");
            serviceAlbum.SearchAlbums("https://us.napster.com/artist/");
            Console.WriteLine("");
            Console.WriteLine("Proceso Finalizado.");

            Console.WriteLine("Listo ahora la base de datos ya tiene informacion.");
            Console.ReadLine();
        }
    }
}
