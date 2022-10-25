using AnnaTest;
using System.Security.Cryptography.X509Certificates;

FileStream fileStream = new FileStream("C:\\Prog\\AnnaTest1\\AnnaTest\\TextFileToParse.txt", FileMode.Open);
using (StreamReader reader = new StreamReader(fileStream))
{
    List<Detail> details = new List<Detail>();

    string line;
    while( (line = reader.ReadLine()) != null)
    {
        string[] fields = line.Split('%');
        //Console.WriteLine(line);
        
        Detail detail = new Detail();
        detail.No = Convert.ToInt32(fields[0]);
        detail.Name = fields[1];
        detail.Qty = Convert.ToInt32(fields[2]);

        //var query = from d in details
        //            where d.Name == detail.Name
        //            && d.No == detail.Qty
        //            select d;

        var query = details.Find(x => x.No == detail.No && x.No == detail.No);

        if (query == null)
        {
            details.Add(detail);
        } else
        {
            query.Qty += detail.Qty;            
        }
    }

    foreach( Detail d in details)
    {
        Console.WriteLine($"{d.No}%{d.Name}%{d.Qty}");
    }
    
}