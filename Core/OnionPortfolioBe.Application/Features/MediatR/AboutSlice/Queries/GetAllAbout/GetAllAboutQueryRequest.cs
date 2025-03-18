using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Queries;

public class GetAllAboutQueryRequest : IRequest<IList<GetAllAboutQueryResponse>>
{
}
