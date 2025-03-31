using AdvancedLinq;
using AdvancedLinq.Models;

var db = new Database();
var service = new Service(db);

// Generation Operators Examples

// empty employee sequence
var emptySequence = Enumerable.Empty<Employee>();

// repeated the department 3 times in a sequence
var repeatedSequence = Enumerable.Repeat(new Department { Id = 1, Name = "IT" }, 3);

// range sequence
var rangeSequence = Enumerable
    .Range(1, 5)
    .Select(x => new Department { Id = x, Name = $"Department {x}" });
