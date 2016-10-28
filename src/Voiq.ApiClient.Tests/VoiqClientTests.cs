using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voiq.ApiClient.Enums;
using Voiq.ApiClient.Exceptions;
using Voiq.ApiClient.Models;

namespace Voiq.ApiClient.Tests
{

    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class VoiqClientTests
    {

        /// <summary>
        /// 
        /// 
        /// </summary>



        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public async Task VoiqClient_LoginSuccess()
        {
            Func<Task> asyncFunction = async () =>
            {
                await VoiqClient.LoginAsync();
            };
            asyncFunction.ShouldNotThrow();
            VoiqClient.AuthTokens.Should().NotBeNull();
            VoiqClient.AuthTokens.IsExpired.Should().BeFalse();
            VoiqClient.AuthTokens = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task VoiqClient_LoginFailure()
        {
            Func<Task> asyncFunction = async () =>
            {
                await BadClient.LoginAsync();
            };
            asyncFunction.ShouldThrow<VoiqException>();
            BadClient.AuthTokens.Should().BeNull();
            BadClient.AuthTokens = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task VoiqClient_RefreshToken()
        {
            Func<Task> asyncFunction = async () =>
            {
                await VoiqClient.LoginAsync();
            };
            asyncFunction.ShouldNotThrow();
            VoiqClient.AuthTokens.Should().NotBeNull();
            VoiqClient.AuthTokens.IsExpired.Should().BeFalse();

            var expirationTime = VoiqClient.AuthTokens.ExpiresUtc;

            await Task.Delay(10000);

            Func<Task> asyncFunction2 = async () =>
            {
                await VoiqClient.RefreshTokenAsync();
            };
            asyncFunction2.ShouldNotThrow();
            VoiqClient.AuthTokens.Should().NotBeNull();
            VoiqClient.AuthTokens.IsExpired.Should().BeFalse();
            VoiqClient.AuthTokens.ExpiresUtc.Should().BeAfter(expirationTime);
            VoiqClient.AuthTokens = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task VoiqClient_GetAllCampaigns_WithEverything()
        {
            Func<Task> asyncFunction = async () =>
            {
                await VoiqClient.LoginAsync();
            };
            asyncFunction.ShouldNotThrow();
            VoiqClient.AuthTokens.Should().NotBeNull();
            VoiqClient.AuthTokens.IsExpired.Should().BeFalse();

            List<CampaignSummary> campaigns = null;
            Func<Task> asyncFunction2 = async () =>
            {
                campaigns = await VoiqClient.Campaigns.GetAllAsync();
            };
            asyncFunction2.ShouldNotThrow();
            campaigns.Should().NotBeNull().And.NotBeEmpty();
            //campaigns[0].DateEnds.Should().NotBeNull();
            //campaigns[0].DateStarts.Should().NotBeNull();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task VoiqClient_GetCampaign_WithEverything()
        {
            Func<Task> asyncFunction = async () =>
            {
                await VoiqClient.LoginAsync();
            };
            asyncFunction.ShouldNotThrow();
            VoiqClient.AuthTokens.Should().NotBeNull();
            VoiqClient.AuthTokens.IsExpired.Should().BeFalse();

            Campaign campaign = null;
            Func<Task> asyncFunction2 = async () =>
            {
            };
            asyncFunction2.ShouldNotThrow();
            campaign.Should().NotBeNull();
            campaign.CampaignCallFrequencies.Should().NotBeNull();
            campaign.Leads.Should().NotBeNull().And.NotBeEmpty();
            campaign.Leads.SelectMany(c => c.Calls).Should().NotBeNull().And.NotBeEmpty();
            campaign.SurveyResults.Should().NotBeNull().And.NotBeEmpty();
            campaign.Surveys.Should().NotBeNull().And.NotBeEmpty();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task VoiqClient_GetCampaign_WithEverything_ByDate()
        {
            Func<Task> asyncFunction = async () =>
            {
                await VoiqClient.LoginAsync();
            };
            asyncFunction.ShouldNotThrow();
            VoiqClient.AuthTokens.Should().NotBeNull();
            VoiqClient.AuthTokens.IsExpired.Should().BeFalse();

            Campaign campaign = null;
            Func<Task> asyncFunction2 = async () =>
            {
            };
            asyncFunction2.ShouldNotThrow();
            campaign.Should().NotBeNull();
            campaign.CampaignCallFrequencies.Should().NotBeNull();
            campaign.Leads.Should().NotBeNull().And.NotBeEmpty();
            campaign.Leads.SelectMany(c => c.Calls).Should().NotBeNull().And.NotBeEmpty();
            campaign.Leads.SelectMany(c => c.Calls).Where(c => c.DateCreated.Date == new DateTime(2016, 10, 11).Date).Count().Should().Be(478);
            campaign.Leads.SelectMany(c => c.Calls).Where(c => c.DateCreated.Date == new DateTime(2016, 10, 12).Date).Count().Should().Be(0);
            campaign.Surveys.Should().NotBeNull().And.NotBeEmpty();
            campaign.SurveyResults.Should().NotBeNull().And.NotBeEmpty();
            campaign.SurveyResults.Where(c => c.DateCreated.Date == new DateTime(2016, 10, 11).Date).Count().Should().Be(7);
            campaign.SurveyResults.Where(c => c.DateCreated.Date == new DateTime(2016, 10, 12).Date).Count().Should().Be(0);
        }

    }

}
