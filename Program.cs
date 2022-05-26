using AppSeries.src.Classes;
using AppSeries.src.Enums;
using static System.Console;


namespace AppSeries
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string userOption = GetOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1": ListSeries(); break;
                    case "2": InsertSeries(); break;
                    case "3": UpdateSeries(); break;
                    case "4": DeleteSeries(); break;
                    case "5": ViewSeries(); break;
                    case "C": Clear(); break;

                    default: throw new ArgumentOutOfRangeException();
                }

                userOption = GetOption();
            }

            WriteLine("Thank you for using our services!");
            ReadLine();
        }

        private static void ListSeries()
        {
            WriteLine("Series list:");

            var list = repository.List();

            if (list.Count == 0)
            {
                WriteLine("No series found.");
                return;
            }

            foreach (var series in list)
            {
                var deleted = series.ReturnDeleted();
                WriteLine("#ID {0}: - {1} - {2}", series.ReturnId(), series.ReturnTitle(), (deleted ? "*Deleted*" : ""));
            }
        }

        private static void InsertSeries()
        {
            WriteLine("Insert new series:");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }

            WriteLine("Choose a genre from given options: ");
            int genreInput = int.Parse(ReadLine());

            WriteLine("Type the title of the series: ");
            string? titleInput = ReadLine();

            WriteLine("Type the year of the series: ");
            int yearInput = int.Parse(ReadLine());

            WriteLine("Type a description for the series: ");
            string? descInput = ReadLine();

            Series newSeries = new Series(id: repository.NextId(),
                                            genre: (Genre)genreInput,
                                            title: titleInput,
                                            year: yearInput,
                                            description: descInput);

            repository.Insert(newSeries);
        }

        private static void UpdateSeries()
        {
            WriteLine("Digite o ID da série: ");
            int seriesIndex = int.Parse(ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }

            WriteLine("Choose a genre from given options: ");
            int genreInput = int.Parse(ReadLine());

            WriteLine("Type the title of the series: ");
            string? titleInput = ReadLine();

            WriteLine("Type the year of the series: ");
            int yearInput = int.Parse(ReadLine());

            WriteLine("Type a description for the series: ");
            string? descInput = ReadLine();

            Series updatedSeries = new Series(id: seriesIndex,
                                            genre: (Genre)genreInput,
                                            title: titleInput,
                                            year: yearInput,
                                            description: descInput);

            repository.Update(seriesIndex, updatedSeries);
        }

        private static void DeleteSeries()
        {
            WriteLine("Type the ID for the series you want to delete: ");
            int seriesIndex = int.Parse(ReadLine());

            repository.Delete(seriesIndex);
        }

        private static void ViewSeries()
        {
            WriteLine("Type the ID for the series you want to see: ");
            int seriesIndex = int.Parse(ReadLine());

            var series = repository.ReturnById(seriesIndex);

            WriteLine(series);
        }

        public static string GetOption()
        {
            WriteLine();
            WriteLine("Choose an option:");

            WriteLine("1- List series");
            WriteLine("2- Insert new series");
            WriteLine("3- Update series");
            WriteLine("4- Delete series");
            WriteLine("5- View series");
            WriteLine("C- Clear console");
            WriteLine("X- Exit");
            WriteLine();

            string userOption = ReadLine().ToUpper();
            WriteLine();
            return userOption;
        }
    }
}