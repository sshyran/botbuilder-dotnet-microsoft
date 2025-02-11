﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Bot.Builder.Parsers.LU;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Bot.Builder.Parsers.LU.Tests.Parser
{
    public class LuParserTests
    {
        [Theory]
        [InlineData("LU_Sections")]
        [InlineData("SectionsLU")]
        [InlineData("ImportAllLu")]
        public void ParseLuContent(string fileName)
        {
            // var luContent = "# Help"+ Environment.NewLine + "- help" + Environment.NewLine + "- I need help" + Environment.NewLine + "- please help";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Fixtures", fileName + ".txt");
            Console.WriteLine(path);
            var luContent = File.ReadAllText(path);
            luContent = luContent.Substring(0, luContent.Length);
            var result = LuParser.Parse(luContent);
            if (string.Equals(fileName, "LU_Sections", StringComparison.Ordinal) || string.Equals(fileName, "SectionsLU", StringComparison.Ordinal))
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    fileName += "_Windows";
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    fileName += "_Unix";
                }
            }

            LuResource expected = JsonConvert.DeserializeObject<LuResource>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Fixtures", fileName + ".json")));
            var serializedResult = JsonConvert.SerializeObject(result).Replace("\\r", string.Empty);
            var serializedExpected = JsonConvert.SerializeObject(expected).Replace("\\r", string.Empty);
            Assert.Equal(serializedResult, serializedExpected);
        }

        [Theory]
        [InlineData("testLU1")]
        [InlineData("testLU2")]
        [InlineData("testLU3")]
        [InlineData("testLU4")]
        [InlineData("testLU5")]
        [InlineData("testLU6")]
        [InlineData("testLU7")]
        [InlineData("testLU8")]
        [InlineData("testLU9")]
        [InlineData("testLU10")]
        [InlineData("testLU11")]
        [InlineData("testLU12")]
        [InlineData("testLU13")]
        [InlineData("testLU14")]
        [InlineData("testLU15")]
        [InlineData("testLU16")]
        [InlineData("testLU17")]
        [InlineData("testLU18")]
        [InlineData("testLU19")]
        [InlineData("testLU20")]
        [InlineData("testLU21")]
        [InlineData("testLU22")]
        [InlineData("testLU23")]
        [InlineData("testLU24")]
        [InlineData("testLU25")]
        [InlineData("testLU26")]
        [InlineData("testLU27")]
        [InlineData("testLU28")]
        [InlineData("testLU29")]
        [InlineData("testLU30")]
        [InlineData("testLU31")]
        [InlineData("testLU32")]
        [InlineData("testLU33")]
        [InlineData("testLU34")]
        [InlineData("testLU35")]
        [InlineData("testLU36")]
        [InlineData("testLU37")]
        [InlineData("testLU38")]
        [InlineData("testLU39")]
        [InlineData("testLU40")]
        [InlineData("testLU41")]
        [InlineData("testLU42")]
        [InlineData("testLU43")]
        [InlineData("testLU44")]
        [InlineData("testLU45")]
        [InlineData("testLU46")]
        [InlineData("testLU47")]
        [InlineData("testLU48")]
        [InlineData("testLU49")]
        [InlineData("testLU50")]
        [InlineData("testLU51")]
        [InlineData("testLU52")]
        [InlineData("testLU53")]
        [InlineData("testLU54")]
        [InlineData("testLU55")]
        [InlineData("testLU56")]
        [InlineData("testLU57")]
        [InlineData("testLU58")]
        [InlineData("testLU59")]
        [InlineData("testLU60")]
        [InlineData("testLU61")]
        [InlineData("testLU62")]
        [InlineData("testLU63")]
        [InlineData("testLU64")]
        [InlineData("testLU65")]
        [InlineData("testLU66")]
        [InlineData("testLU67")]
        [InlineData("testLU68")]
        [InlineData("testLU69")]
        [InlineData("testLU70")]
        [InlineData("testLU71")]
        [InlineData("testLU72")]
        [InlineData("testLU73")]
        [InlineData("testLU74")]
        [InlineData("testLU75")]
        [InlineData("testLU76")]
        [InlineData("testLU77")]
        [InlineData("testLU78")]
        [InlineData("testLU79")]
        [InlineData("testLU80")]
        [InlineData("testLU81")]
        [InlineData("testLU82")]
        [InlineData("testLU83")]
        [InlineData("testLU84")]
        [InlineData("testLU85")]
        [InlineData("testLU86")]
        [InlineData("testLU87")]
        [InlineData("testLU88")]
        [InlineData("testLU89")]
        [InlineData("testLU90")]
        [InlineData("testLU91")]
        [InlineData("testLU92")]
        [InlineData("testLU93")]
        [InlineData("testLU94")]
        [InlineData("testLU95")]
        [InlineData("testLU96")]
        [InlineData("testLU97")]
        [InlineData("testLU98")]
        [InlineData("testLU99")]
        [InlineData("testLU100")]
        [InlineData("testLU101")]
        [InlineData("testLU102")]
        [InlineData("testLU103")]
        [InlineData("testLU104")]
        [InlineData("testLU105")]
        [InlineData("testLU106")]
        [InlineData("testLU107")]
        [InlineData("testLU108")]
        [InlineData("testLU109")]
        [InlineData("testLU110")]
        [InlineData("testLU111")]
        [InlineData("testLU112")]
        [InlineData("testLU113")]
        [InlineData("testLU114")]
        [InlineData("testLU115")]
        [InlineData("testLU116")]
        [InlineData("testLU117")]
        [InlineData("testLU118")]
        [InlineData("testLU119")]
        [InlineData("testLU120")]
        [InlineData("testLU121")]
        [InlineData("testLU122")]
        [InlineData("testLU123")]
        [InlineData("testLU124")]
        [InlineData("testLU125")]
        [InlineData("testLU126")]
        [InlineData("testLU127")]
        [InlineData("testLU128")]
        [InlineData("testLU129")]
        [InlineData("testLU130")]
        [InlineData("testLU131")]
        [InlineData("testLU132")]
        [InlineData("testLU133")]
        [InlineData("testLU134")]
        [InlineData("testLU135")]
        [InlineData("testLU136")]
        [InlineData("testLU137")]
        [InlineData("testLU138")]
        [InlineData("testLU139")]
        [InlineData("testLU140")]
        [InlineData("testLU141")]
        [InlineData("testLU142")]
        [InlineData("testLU143")]
        [InlineData("testLU144")]
        [InlineData("testLU145")]
        [InlineData("testLU146")]
        [InlineData("testLU147")]
        [InlineData("testLU148")]
        [InlineData("testLU149")]
        [InlineData("testLU150")]
        [InlineData("testLU151")]
        [InlineData("testLU152")]
        [InlineData("testLU153")]
        [InlineData("testLU154")]
        [InlineData("testLU155")]
        [InlineData("testLU156")]
        [InlineData("testLU157")]
        [InlineData("testLU158")]
        [InlineData("testLU159")]
        [InlineData("testLU160")]
        [InlineData("testLU161")]
        [InlineData("testLU162")]
        [InlineData("testLU163")]
        [InlineData("testLU164")]
        [InlineData("testLU165")]
        [InlineData("testLU166")]
        [InlineData("testLU167")]
        [InlineData("testLU168")]
        [InlineData("testLU169")]
        [InlineData("testLU170")]
        [InlineData("testLU171")]
        [InlineData("testLU172")]
        [InlineData("testLU173")]
        [InlineData("testLU174")]
        [InlineData("testLU175")]
        [InlineData("testLU176")]
        [InlineData("testLU177")]
        [InlineData("testLU178")]
        [InlineData("testLU179")]
        [InlineData("testLU180")]
        [InlineData("testLU181")]
        [InlineData("testLU182")]
        [InlineData("testLU183")]
        [InlineData("testLU184")]
        [InlineData("testLU185")]
        [InlineData("testLU186")]
        [InlineData("testLU187")]
        [InlineData("testLU188")]
        [InlineData("testLU189")]
        [InlineData("testLU190")]
        [InlineData("testLU191")]
        [InlineData("testLU192")]
        [InlineData("testLU193")]
        [InlineData("testLU194")]
        [InlineData("testLU195")]
        [InlineData("testLU196")]
        [InlineData("testLU197")]
        [InlineData("testLU198")]
        [InlineData("testLU199")]
        [InlineData("testLU200")]
        [InlineData("testLU201")]
        [InlineData("testLU202")]
        [InlineData("testLU203")]
        [InlineData("testLU204")]
        [InlineData("testLU205")]
        [InlineData("testLU206")]
        [InlineData("testLU207")]
        [InlineData("testLU208")]
        [InlineData("testLU209")]
        [InlineData("testLU210")]
        [InlineData("testLU211")]
        [InlineData("testLU212")]
        [InlineData("testLU213")]
        [InlineData("testLU214")]
        [InlineData("testLU215")]
        [InlineData("testLU216")]
        [InlineData("testLU217")]
        [InlineData("testLU218")]
        [InlineData("testLU219")]
        [InlineData("testLU220")]
        [InlineData("testLU221")]
        [InlineData("testLU222")]
        [InlineData("testLU223")]
        [InlineData("testLU224")]
        [InlineData("testLU225")]
        [InlineData("testLU226")]
        [InlineData("testLU227")]
        [InlineData("testLU228")]
        [InlineData("testLU229")]
        [InlineData("testLU230")]
        [InlineData("testLU231")]
        [InlineData("testLU232")]
        [InlineData("testLU233")]
        [InlineData("testLU234")]
        [InlineData("testLU235")]
        [InlineData("testLU236")]
        [InlineData("testLU237")]
        [InlineData("testLU238")]
        [InlineData("testLU239")]
        [InlineData("testLU240")]
        [InlineData("testLU241")]
        [InlineData("testLU242")]
        [InlineData("testLU243")]
        [InlineData("testLU244")]
        [InlineData("testLU245")]
        [InlineData("testLU246")]
        [InlineData("testLU247")]
        [InlineData("testLU248")]
        [InlineData("testLU249")]
        [InlineData("testLU250")]
        [InlineData("testLU251")]
        [InlineData("testLU252")]
        [InlineData("testLU253")]
        [InlineData("testLU254")]
        [InlineData("testLU255")]
        [InlineData("testLU256")]
        [InlineData("testLU257")]
        [InlineData("testLU258")]
        [InlineData("testLU259")]
        [InlineData("testLU260")]
        [InlineData("testLU261")]
        [InlineData("testLU262")]
        [InlineData("testLU263")]
        [InlineData("testLU264")]
        [InlineData("testLU265")]
        [InlineData("testLU266")]
        [InlineData("testLU267")]
        [InlineData("testLU268")]
        [InlineData("testLU269")]
        [InlineData("testLU270")]
        [InlineData("testLU271")]
        [InlineData("testLU272")]
        [InlineData("testLU273")]
        [InlineData("testLU274")]
        [InlineData("testLU275")]
        [InlineData("testLU276")]
        [InlineData("testLU277")]
        [InlineData("testLU278")]
        [InlineData("testLU279")]
        [InlineData("testLU280")]
        [InlineData("testLU281")]
        [InlineData("testLU282")]
        [InlineData("testLU283")]
        [InlineData("testLU284")]
        [InlineData("testLU285")]
        [InlineData("testLU286")]
        [InlineData("testLU287")]
        [InlineData("testLU288")]
        [InlineData("testLU289")]
        [InlineData("testLU290")]
        [InlineData("testLU291")]
        [InlineData("testLU292")]
        [InlineData("testLU293")]
        [InlineData("testLU294")]
        [InlineData("testLU295")]
        [InlineData("testLU296")]
        [InlineData("testLU297")]
        [InlineData("testLU298")]
        [InlineData("testLU299")]
        [InlineData("testLU300")]
        [InlineData("testLU301")]
        [InlineData("testLU302")]
        [InlineData("testLU303")]
        [InlineData("testLU304")]
        [InlineData("testLU305")]
        [InlineData("testLU306")]
        [InlineData("testLU307")]
        [InlineData("testLU308")]
        [InlineData("testLU309")]
        [InlineData("testLU310")]
        public void ParseLuContentAutomated(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Fixtures", fileName + ".txt");
            var luContent = File.ReadAllText(path);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && luContent.Contains("\r")) 
            {
                luContent = luContent.Replace("\r", string.Empty);
            }

            var result = LuParser.Parse(luContent);
            var serializedResult = JsonConvert.SerializeObject(result);

            LuResource expected = JsonConvert.DeserializeObject<LuResource>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Fixtures", fileName + ".json")).Replace("\r", string.Empty));
            var serializedExpected = JsonConvert.SerializeObject(expected);

            var serExpected = SanitizeString(serializedExpected);
            var serResult = SanitizeString(serializedResult);

            Assert.Equal(serExpected, serResult);
        }

        private string SanitizeString(string s)
        {
            return s.Replace("\\r\\n", "\\n");
        }
    }
}
