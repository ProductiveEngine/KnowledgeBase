﻿using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Accessors;
using DomainClasses.Models;
using DomainClasses.ViewModels;

namespace Services.BLService.BL
{
    public class WizardBL
    {
        private readonly WizardAccessor _wizardAccessor;

        public WizardBL()
        {
            _wizardAccessor = new WizardAccessor();
        }

        public WizardVO FindById(int problemId)
        {
            WizardVO wizard = new WizardVO();

            //_wizardAccessor.RepoProblem.AllIncluding(s => s.Solutions).FirstOrDefault();

            wizard.Problem = _wizardAccessor.RepoProblem.Find(problemId);

            if (wizard.Problem != null && wizard.Problem.ProblemID > 0)
            {
                List<SolutionVO> solutions = wizard.Problem.Solutions.ToList();

                if (solutions != null && solutions.Count > 0)
                {
                    SolutionVO solution = solutions.FirstOrDefault();
                    wizard.Solution = solution;

                    if (wizard.Solution.Steps != null && wizard.Solution.Steps.Count > 0)
                    {
                       // wizard.Steps = wizard.Solution.Steps.ToList();
                    }
                }
                
            }

            return wizard;
        }

        public Boolean Save(WizardVO vo)
        {
            //vo = null;
            //vo = new WizardVO();

            //vo.Problem.Title = "TEST 4";
            //vo.Problem.SubCategoryID = 1;

            if (vo.Problem != null)
            {         
            vo.Problem.Solutions = null;
            _wizardAccessor.RepoProblem.InsertOrUpdate(vo.Problem);
            _wizardAccessor.Save();
            }

        if (vo.Solution != null && vo.Problem != null && vo.Problem.ProblemID > 0)
            {
                //vo.Solution.Problem = null;
                vo.Solution.Steps = null;
                vo.Solution.ProblemID = vo.Problem.ProblemID;
                _wizardAccessor.RepoSolution.InsertOrUpdate(vo.Solution);
                _wizardAccessor.Save();
            }

            if (vo.Steps != null && vo.Steps.Count > 0 && vo.Solution != null && vo.Solution.SolutionId > 0)
            {                                
                foreach (StepVO step in vo.Steps)
                {
                    step.SolutionID = vo.Solution.SolutionId;
                    _wizardAccessor.RepoStep.InsertOrUpdate(step);
                }
                _wizardAccessor.Save();
            }
            
            return true;
        } 
    }
}
