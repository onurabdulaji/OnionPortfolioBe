using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPortfolioBe.Domain.Entities;
public class Stat : BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int? Client { get; set; }
    public int? Project { get; set; }
    public int? Support { get; set; }
    public int? Worker { get; set; }
    public Stat()
    {

    }
    public Stat(int client, int project, int support, int worker)
    {
        Id = Guid.NewGuid();
        Client = client;
        Project = project;
        Support = support;
        Worker = worker;
    }
}
