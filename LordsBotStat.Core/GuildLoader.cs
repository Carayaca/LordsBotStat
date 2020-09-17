namespace LordsBotStat.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;

    /// <summary>
    /// The GuildLoader class.
    /// </summary>
    public class GuildLoader
    {
        /// <summary>
        /// Loads the members list.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>IList{string}.</returns>
        public IList<string> LoadMembersList(string fileName)
        {
            IList<string> players = new List<string>();

            using (var doc = SpreadsheetDocument.Open(fileName, false))
            {
                var sheets = doc.WorkbookPart.Workbook.GetFirstChild<Sheets>();
                var first = sheets.Descendants<Sheet>().FirstOrDefault(sh => sh.Name == "Sheet");
                if (first == null)
                {
                    return players;
                }

                var theWorksheet = ((WorksheetPart) doc.WorkbookPart.GetPartById(first.Id)).Worksheet;
                var sheetData = theWorksheet.GetFirstChild<SheetData>();

                foreach (var openXmlElement in sheetData)
                {
                    var r = (Row) openXmlElement;
                    if (r.RowIndex.Value == 1) // пропустим Header
                    {
                        continue;
                    }

                    var cells = r.Elements<Cell>().ToArray();
                    var cell = cells.Length > 0 ? cells[1] : null; // ячейка с ником игрока

                    if (cell?.InnerText.Any() ?? false)
                    {
                        if (cell.DataType != null)
                        {
                            switch (cell.DataType.Value)
                            {
                                case CellValues.SharedString:
                                    var stringTable = doc.WorkbookPart.GetPartsOfType<SharedStringTablePart>()
                                            .FirstOrDefault();
                                    if (stringTable != null)
                                    {
                                        var value =
                                            stringTable.SharedStringTable
                                                .ElementAt(int.Parse(cell.InnerText)).InnerText;
                                        players.Add(value);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }

            return players;
        }
    }
}
