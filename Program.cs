namespace MyFirstWeb;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        app.UseDefaultFiles();
        app.UseStaticFiles();


        app.MapGet("/", Index);

        app.MapGet("/HRU", HRU);

        app.MapGet("/HRU/Surprise", Surprise);

        app.MapGet("/AboutMe", () => "Name: Mark. Age: 12. Gender: Male. Favourite color: Purple");

        app.MapGet("/Sum/{digit1}/{digit2}", SumTotal );

        app.MapGet("/Rick", RickRoll);

        app.MapGet("/Ocelot", Ocelot);

        app.Run();
    }

public static IResult HRU()
{
    string html_content = """
        <script>
            window.location.href = "https://www.youtube.com/watch?v=SDb13swjj8M&list=RDSDb13swjj8M&start_radio=1";
        </script>
        """;

    return Results.Content(
        html_content,
        "text/html",
        System.Text.Encoding.UTF8
    );
}

public static IResult Surprise()
{
    string html_content = """
        <script>
            window.location.replace(
                "https://www.youtube.com/watch?v=SDb13swjj8M&list=RDSDb13swjj8M&start_radio=1"
            );
        </script>
        """;

    return Results.Content(
        html_content,
        "text/html",
        System.Text.Encoding.UTF8
    );
}

    public static int SumTotal(int digit1, int digit2)
    {
        return digit1 + digit2;
    }

    public static IResult Index()
    {

    string hmtl_content = """
                          <!DOCTYPE html>
                          <html>
                          <head>
                          <style>
                          body {
                            background-color: linen;
                          }
                          
                          h1 {
                            color: maroon;
                            margin-left: 40px;
                          } 
                          </style>
                          </head>
                          <body>
                          
                          <h1>This is a heading</h1>
                          <p>This is a paragraph.</p>
                          
                          </body>
                          </html>
                          """;
    return Results.Content(hmtl_content, "text/html", System.Text.Encoding.UTF8); 
    }

    public static IResult RickRoll()
    {
        string hmtl_content = """<a href=https://youtu.be/dQw4w9WgXcQ?si=by2o9uMbg2V3nhqm> Click ME!""";

        return Results.Content(hmtl_content, "text/html", System.Text.Encoding.UTF8);
    }

    public static IResult Ocelot()
    {
        return Results.File(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ocelot.html"), "text/html");
    }
}
