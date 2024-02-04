
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Document = QuestPDF.Fluent.Document;

namespace DotNet_2_imtihon_Telegram_Bot.Admin
{
    public class Admin_PDF
    {
        public async Task SendAllUsers2(string text, string folderpath)
        {
            QuestPDF.Settings.License = LicenseType.Professional;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                      .Text("Hello PDF!")
                      .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                      .PaddingVertical(1, Unit.Centimetre)
                      .Column(x =>
                      {
                          x.Spacing(20);

                          x.Item().Text( $"{text}");
                      });

                    page.Footer()
                      .AlignCenter()
                      .Text(x =>
                      {
                          x.Span("Page ");
                          x.CurrentPageNumber();
                      });
                });
            })
    .GeneratePdf(Path.Combine(folderpath, "hello.pdf"));


        }
    }
}
