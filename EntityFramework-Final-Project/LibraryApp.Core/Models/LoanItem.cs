﻿namespace LibraryApp.Core.Models
{
    public class LoanItem
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int LoanId { get; set; }
        public Loan Loan { get; set; }
    }
}
