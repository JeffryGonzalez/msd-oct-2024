﻿using HelpDesk.Api.Catalog.ReadModels;
using HelpDesk.Api.SoftwareCenter;
using Marten;
using Marten.Events.Aggregation;

namespace HelpDesk.Api.Catalog.Endpoints;
[Produces("application/json")]
public class CatalogController(IDocumentSession session) : ControllerBase
{
    /// <summary>
    /// Gives you the full software catalog. Note: Users may not be entitled to all of these items.
    /// To get a list of the items you are entitled to, see /user/catalog
    /// </summary>
    [HttpGet("/catalog")]
    [ApiExplorerSettings(GroupName = "Catalog")]

    public async Task<ActionResult<IReadOnlyList<CatalogItem>>> GetFullCatalogAsync()
    {

        var response = await session.Query<CatalogItem>().ToListAsync();
        return Ok(response);
    }
}


