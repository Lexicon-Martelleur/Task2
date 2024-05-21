using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.constant;

namespace Task2.model;

internal record class MoviePrice(
    double Price,
    string CurrencyName,
    AgeGroup AgeGroup
);
