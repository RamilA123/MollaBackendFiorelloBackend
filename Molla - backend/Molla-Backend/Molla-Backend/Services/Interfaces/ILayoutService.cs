using System;
using Molla_Backend.Models;
using Molla_Backend.ViewModels;

namespace Molla_Backend.Services.Interfaces
{
	public interface ILayoutService
	{
        Dictionary<string, string> GetAllDatas();
        void SaveAction();
    }
}

