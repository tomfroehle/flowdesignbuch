namespace csvviewer;

public class Program
{
    public static void Main(string[] args)
    {
        var interactors = Interactors.Create(args);
        var ui = new Ui();

        void Start()
        {
            var records = interactors.FirstPage();
            Ui.Display(records);
        }

        ui.MoveFirst += () =>
        {
            var records = interactors.FirstPage();
            Ui.Display(records);
        };
        ui.MovePrev += () =>
        {
            var records = interactors.PrevPage();
            Ui.Display(records);
        };
        ui.MoveNext += () =>
        {
            var records = interactors.NextPage();
            Ui.Display(records);
        };
        ui.MoveLast += () =>
        {
            var records = interactors.LastPage();
            Ui.Display(records);
        };

        Start();
        ui.Run();
    }
}