namespace Okosotthon
{
    public class Program
    {
        static void Main(string[] args)
        {
            Termosztat termosztat = new Termosztat("TH-01", "Nappali termosztát", 22.0);
            OkosZar zar = new OkosZar("LK-01", "Bejárati zár", "1234");
            OkosotthonKozpont kozpont = new OkosotthonKozpont();

            kozpont.EszkozHozzaadasa(termosztat);
            kozpont.EszkozHozzaadasa(zar);

            Console.WriteLine($"Sikeres tesztek offline: {kozpont.RendszerDiagnosztikaFuttatasa()}");

            kozpont.OsszesCsatlakoztatasa();

            Console.WriteLine($"Sikeres tesztek online: {kozpont.RendszerDiagnosztikaFuttatasa()}");

            termosztat.ParancsVegrehajtasa("BEALLIT_HOMERSEKLET:24.5");
            Console.WriteLine(termosztat.AllapotJelentes());

            zar.ParancsVegrehajtasa("NYITAS:1234");
            Console.WriteLine(zar.AllapotJelentes());

            zar.ParancsVegrehajtasa("ZARAS");
            Console.WriteLine(zar.AllapotJelentes());

            termosztat.ParancsVegrehajtasa("BEALLIT_HOMERSEKLET:50.0");
            Console.WriteLine($"Sikeres tesztek hibás hőmérséklettel: {kozpont.RendszerDiagnosztikaFuttatasa()}");

            zar.GyariBeallitasokVisszaallitasa();
            Console.WriteLine(zar.AllapotJelentes());

            zar.ParancsVegrehajtasa("NYITAS:0000");
            Console.WriteLine(zar.AllapotJelentes());
        }
    }
}