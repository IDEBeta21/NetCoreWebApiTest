﻿using NetCoreWebApiTest.DOTs;

namespace NetCoreWebApiTest.Services
{
    public interface ICharacterServices
    {
        List<GetCharacterResponse> GetAllCharacters();
    }
}