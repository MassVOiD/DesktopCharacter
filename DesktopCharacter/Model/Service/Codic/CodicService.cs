﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopCharacter.Model.Repository;
using DesktopCharacter.Model.Database.Domain;
using DesktopCharacter.Util;
using System.IO;

namespace DesktopCharacter.Model.Service.Codic
{
    class CodicService
    {
        public static CodicService Instance { get; } = new CodicService();

        private CodicUser _codicRepository;

        public CodicService()
        {
            _codicRepository = CodicRepository.Instance.Load();
        }

        /// <summary>
        /// テキストをCodicに投げて翻訳を受け取ります
        /// </summary>
        /// <param name="text"></param>
        public async Task<CodicFormat> translateAsync(string text)
        {
            ParameterBuild parameter = new ParameterBuild();
            parameter.Parameter.Add("text", text);

            CodicAPI api = new CodicAPI();
            CodicFormat result = await api.translateAscyn(parameter.Convert(), _codicRepository.Token);
            return result;
        }
    }
}
