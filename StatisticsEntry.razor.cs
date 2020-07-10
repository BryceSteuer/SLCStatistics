using Microsoft.AspNetCore.Components;
using SLCRoad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SLCRoad.Data;
using SLCRoad.Data.Model;
using BlazorStrap;
using SLCRoad.Pages.Statistics;
using GridBlazor;
using GridBlazor.Pages;

namespace SLCRoad.Pages.Statistics
{
    [Route(PagePaths.StatisticsEntry)]
    public partial class StatisticsEntry
    {

        internal enum Tabs
        {

            PersonAccount = 1

        }


        #region Inject 
#pragma warning disable CS8618
        [Inject]
        public PeopleAccess<Person> _peopleAccess { get; set; }


        #endregion

      


       

        private bool loadingPersonAcctDone { get; set; }
        private IEnumerable<Person> PeopleList { get; set; } = new List<Person>();

        private bool _shouldRender;

        public StatisticsData Data { get; set; } = new StatisticsData();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // check if browser storage has saved data already


                await LoadPeopleList();

                await InvokeAsync(StateHasChanged).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Loads and reloads (on data change) people list for typeAhead
        /// </summary>
        private async Task LoadPeopleList()
        {
            var selectedPerson = SelectedPerson?.person_id;
            SelectedPerson = null;

            PeopleList = await _peopleAccess.QueryAsync(
                        _peopleAccess.OptionsItemList(ShowInactive: false));

            _shouldRender = true;
            if (selectedPerson != null)
                SelectedPerson = PeopleList.Where(p => p.person_id == selectedPerson).FirstOrDefault();
        }

        private Person? _selectedPerson;
        private Person? SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
            }
        }

    }

}

