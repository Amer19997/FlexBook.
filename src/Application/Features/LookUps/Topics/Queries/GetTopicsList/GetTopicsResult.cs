using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.Catalog.Dtos;

namespace FlexBook.Application.Features.LookUps.Topics.Queries.GetTopicsList;
public class GetTopicsResult
{
    public List<TopicDto> TopicsList { get; set; }
}

