using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries.GetAboutById
{
    public class GetAboutByIdRequest : IRequest<GetAboutByIdResponse>
    {
        public Guid Id { get; set; }
        public GetAboutByIdRequest(Guid id)
        {
            Id = id;
        }
    }
}
