﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using Contacts.Services.ContactsRepositoryService;
using Contacts.ProxyModels;
using Contacts.Models;

namespace Contacts.ViewModels
{
    public class AddEditPageViewModel : ViewModelBase
    {
        #region Fields
        IContactRepositoryService repositoryService;
        Models.Contacts currentContact;
        ProxyContact _temporaryContact;
        DelegateCommand _goBackSaved;
        DelegateCommand _goBackUnsaved;
        #endregion

        public ProxyContact TemporaryContact
        {
            set { Set(ref _temporaryContact, value); }
            get { return _temporaryContact; }
        }

        #region Constructors
        public AddEditPageViewModel()
        {
            repositoryService = ContactDBService.Instance;
            _goBackSaved = new DelegateCommand(GoBackSavedExecute);
            _goBackUnsaved = new DelegateCommand(GoBackUnsavedExecute);
        }
        #endregion

        #region Navigation events
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            currentContact = parameter == null ? new Models.Contacts() { ID = Guid.NewGuid().ToString() } : null;

            //TODO: Можно ли вместо создания нового прокси-контакта
            //присвоить занчение полю TemporaryContact (Проверить)
            var temporary = new ProxyContact(currentContact)
            {
                FirstName = currentContact.FirstName,
                LastName = currentContact.LastName,
                IsFavorite = currentContact.IsFavorite,
                Email = currentContact.Email,
                PhoneNumber = currentContact.PhoneNumber,
                GroupID = currentContact.GroupID,
                Validator = i =>
                {
                    var u = i as ProxyContact;
                    if (string.IsNullOrEmpty(u.FirstName))
                        u.Properties[nameof(u.FirstName)].Errors.Add("Firstname is required");
                    if (string.IsNullOrEmpty(u.LastName))
                        u.Properties[nameof(u.LastName)].Errors.Add("Lastname is required");
                    else if (u.LastName.Length < 3)
                        u.Properties[nameof(u.LastName)].Errors.Add("Lastname must consist of minimum 3 characters");
                },
            };
            TemporaryContact = temporary;
            TemporaryContact.Validate();

            return Task.CompletedTask;
        }
        #endregion

        #region Commands

        #region Save
        public DelegateCommand GoBackSaved
        {
            get { return _goBackSaved ?? new DelegateCommand(GoBackSavedExecute); }
        }

        public async void GoBackSavedExecute()
        {
            currentContact.FirstName = TemporaryContact.FirstName;
            currentContact.LastName = TemporaryContact.LastName;
            currentContact.IsFavorite = TemporaryContact.IsFavorite;
            currentContact.PhoneNumber = TemporaryContact.PhoneNumber;
            currentContact.Email = TemporaryContact.Email;

            await repositoryService.AddAsync(currentContact);

            NavigationService.Navigate(typeof(Views.MasterDetailPage));
        }
        #endregion

        #region Unsave
        public DelegateCommand GoBackUnSaved
        {
            get { return _goBackUnsaved ?? new DelegateCommand(GoBackSavedExecute); }
        }

        public async void GoBackUnsavedExecute() =>
            await NavigationService.NavigateAsync(typeof(Views.MasterDetailPage));
        #endregion

        #endregion
    }
}
