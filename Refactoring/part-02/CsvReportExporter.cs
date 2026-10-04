using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.part_02
{
    public class CsvReportExporter : ReportExporter
    {
        protected override string Format(List<string[]> rows) =>
        string.Join(Environment.NewLine, rows.Select(r => string.Join(",", r)));
    }
}
