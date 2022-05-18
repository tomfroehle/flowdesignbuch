using System.Collections.Generic;

namespace csvviewer
{
    public class Interactors
    {
        private readonly Paging<Record> _paging;

        private Interactors(Paging<Record> paging)
        {
            _paging = paging;
        }

        public static Interactors Create(string[] args)
        {
            var filename = CommandLine.GetFilename(args);
            var pageLength = CommandLine.GetPageLength(args);
            var lines = FileProvider.ReadFileContent(filename);
            var records = Csv.CreateRecords(lines);
            var paging = new Paging<Record>(records, pageLength);
            return new Interactors(paging);
        }

        public IEnumerable<Record> FirstPage()
        {
            return _paging.ExtractFirstPage();
        }

        public IEnumerable<Record> PrevPage()
        {
            return _paging.ExtractPrevPage();
        }

        public IEnumerable<Record> NextPage()
        {
            return _paging.ExtractNextPage();
        }

        public IEnumerable<Record> LastPage()
        {
            return _paging.ExtractLastPage();
        }
    }
}