﻿using FundooModels;

namespace FundooManager.Interface
{
    public interface ICollaboratorManager
    {
        string AddCollaborator(CollaboratorModel collaboratorModel);
        string DeleteCollaborator(int collaboratorData);
    }
}