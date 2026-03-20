using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SecurityPoliceMG.Domain.Entity.Model;
using Document = QuestPDF.Fluent.Document;

namespace SecurityPoliceMG.Service.Impl.ScaleModule.Report;

public static class GenerateScaleReport
{
    public static Document GenerateReport(Scale model, Guid loggedUserId)
    {
        return Document.Create(container => Compose(container, model, loggedUserId));
    }

    private static void Compose(IDocumentContainer container, Scale model, Guid loggedUserId)
    {
        container.Page(page =>
        {
            page.Margin(30);

            page.Header().Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text($"Escala - {model.Id}")
                        .FontSize(14)
                        .Bold();

                    col.Item().Text("Relatório de Escala")
                        .FontSize(12)
                        .FontColor(Colors.Grey.Medium);

                    col.Item().Text($"Período: {model.StartsAt:dd/MM/yyyy} - {model.FinishedAt:dd/MM/yyyy}")
                        .Bold()
                        .FontSize(10);

                    col.Item().Text($"Status: {model.Status}")
                        .FontSize(10)
                        .Bold()
                        .FontColor(Colors.Blue.Medium);
                });

                row.ConstantItem(50)
                    .Height(50)
                    .Background(Colors.Grey.Lighten3)
                    .AlignCenter()
                    .Image(LoadReportLogo("brasao_de_minas_gerais.png"));
            });

            page.Content().PaddingVertical(20).Column(col =>
            {
                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(2); // Nome
                        columns.RelativeColumn(3); // Email
                        columns.RelativeColumn(2); // Horas Trabalhadas
                        columns.RelativeColumn(2); // UF
                        columns.RelativeColumn(2); // Genero 
                    });

                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Text("Nome").Bold();
                        header.Cell().Element(CellStyle).Text("Email").Bold();
                        header.Cell().Element(CellStyle).Text("Horas Trabalhadas").AlignCenter().Bold();
                        header.Cell().Element(CellStyle).Text("UF").AlignCenter().Bold();
                        header.Cell().Element(CellStyle).Text("Gênero").AlignCenter().Bold();

                        static IContainer CellStyle(IContainer container) =>
                            container.DefaultTextStyle(x => x.SemiBold().FontSize(10)).PaddingVertical(5)
                                .Background(Colors.Grey.Lighten3)
                                .BorderBottom(1)
                                .BorderColor(Colors.Grey.Medium);
                    });

                    foreach (var sc in model.PersonScales)
                    {
                        table.Cell().Element(CellData).Text(sc.Person.Name);
                        table.Cell().Element(CellData).Text(sc.Person.User.Email);
                        table.Cell().Element(CellData).Text(sc.HoursWorked.ToString()).AlignCenter();
                        table.Cell().Element(CellData).Text(sc.Person.Address.City.Uf).AlignCenter();
                        table.Cell().Element(CellData).Text(sc.Person.Gender).AlignCenter();
                    }

                    static IContainer CellData(IContainer container) =>
                        container.DefaultTextStyle(x => x.FontSize(9))
                            .PaddingVertical(2)
                            .BorderBottom(0.5f)
                            .BorderColor(Colors.Grey.Lighten2);
                });

                col.Item().PaddingTop(20).Row(row =>
                {
                    row.RelativeItem(200).Column(summary =>
                    {
                        summary.Item()
                            .PaddingBottom(5)
                            .BorderBottom(1)
                            .BorderColor(Colors.Grey.Lighten2)
                            .Text("Resumo").FontSize(10).Bold();
                        
                        summary.Item().Text($"Total: {model.PersonScales.Count}").FontSize(9);
                        summary.Item().Text($"Gerado Por: {loggedUserId}").FontSize(9);
                        summary.Item().Text($"{model.Description}").FontSize(9).FontColor(Colors.Grey.Darken2);
                    });
                });
            });

            page.Footer()
                .Text(x =>
                {
                    x.Span("Página ");
                    x.CurrentPageNumber();
                    x.Span(" de ");
                    x.TotalPages();
                });
        });
    }

    private static byte[] LoadReportLogo(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Service/Impl/ScaleModule/Report/Image", fileName);
        return File.ReadAllBytes(path);
    }
}