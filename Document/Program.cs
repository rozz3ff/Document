using System;

namespace DocumentProcessing
{
    class MainApp
    {
        static void Main()
        {
            // Запрашиваем у пользователя ввод
            Console.WriteLine("Введите цифру для создания документа:");
            Console.WriteLine("1: PDF");
            Console.WriteLine("2: Word");
            Console.WriteLine("3: Excel");
            Console.WriteLine("4: PowerPoint");

            // Читаем ввод
            string input = Console.ReadLine();
            DocumentCreator creator = null;

            // Определяем, какой тип документа создать
            switch (input)
            {
                case "1":
                    creator = new PdfDocumentCreator();
                    break;
                case "2":
                    creator = new WordDocumentCreator();
                    break;
                case "3":
                    creator = new ExcelDocumentCreator();
                    break;
                case "4":
                    creator = new PowerPointDocumentCreator();
                    break;
                default:
                    Console.WriteLine("Недействительный ввод. Пожалуйста, введите число от 1 до 4.");
                    return;
            }

            // Создаём и обрабатываем документ
            if (creator != null)
            {
                Document document = creator.FactoryMethod();
                document.Open();
                document.Process();
                document.Close();
            }

            // Ожидание перед закрытием программы
            Console.ReadKey();
        }
    }

    // Абстрактный продукт (документ)
    abstract class Document
    {
        public abstract void Open();
        public abstract void Process();
        public abstract void Close();
    }

    // Конкретный продукт (PDF документ)
    class PdfDocument : Document
    {
        public override void Open() => Console.WriteLine("Открытие PDF документа...");
        public override void Process() => Console.WriteLine("Обработка PDF документа...");
        public override void Close() => Console.WriteLine("Закрытие PDF документа...");
    }

    // Конкретный продукт (Word документ)
    class WordDocument : Document
    {
        public override void Open() => Console.WriteLine("Открытие Word документа...");
        public override void Process() => Console.WriteLine("Обработка Word документа...");
        public override void Close() => Console.WriteLine("Закрытие Word документа...");
    }

    // Конкретный продукт (Excel документ)
    class ExcelDocument : Document
    {
        public override void Open() => Console.WriteLine("Открытие Excel документа...");
        public override void Process() => Console.WriteLine("Обработка Excel документа...");
        public override void Close() => Console.WriteLine("Закрытие Excel документа...");
    }

    // Конкретный продукт (PowerPoint документ)
    class PowerPointDocument : Document
    {
        public override void Open() => Console.WriteLine("Открытие PowerPoint документа...");
        public override void Process() => Console.WriteLine("Обработка PowerPoint документа...");
        public override void Close() => Console.WriteLine("Закрытие PowerPoint документа...");
    }

    // Абстрактный создатель
    abstract class DocumentCreator
    {
        public abstract Document FactoryMethod();
    }

    // Конкретный создатель для PDF
    class PdfDocumentCreator : DocumentCreator
    {
        public override Document FactoryMethod() => new PdfDocument();
    }

    // Конкретный создатель для Word
    class WordDocumentCreator : DocumentCreator
    {
        public override Document FactoryMethod() => new WordDocument();
    }

    // Конкретный создатель для Excel
    class ExcelDocumentCreator : DocumentCreator
    {
        public override Document FactoryMethod() => new ExcelDocument();
    }

    // Конкретный создатель для PowerPoint
    class PowerPointDocumentCreator : DocumentCreator
    {
        public override Document FactoryMethod() => new PowerPointDocument();
    }
}

