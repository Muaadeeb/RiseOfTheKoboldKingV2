using LogicSpawn.RPGMaker.API;
using Newtonsoft.Json;
using UnityEngine;

namespace LogicSpawn.RPGMaker.Core
{
    public class MissedHitNode : EndNode
    {

        [JsonIgnore]
        public override string Name
        {
            get { return "Missed"; }
        }

        [JsonIgnore]
        public override string Description
        {
            get { return "End point for an attack or spell that has missed."; }
        }

        [JsonIgnore]
        public override string SubText
        {
            get { return "End point for missed attack."; }
        }

        public override bool ShowInSearch
        {
            get { return false; }
        }

        public override bool ShowTarget
        {
            get { return false; }
        }

        public override bool CanBeDeleted
        {
            get { return false; }
        }

        public MissedHitNode()
        {
            
        }

        protected override void SetupParameters()
        {

        }

        protected override void Eval(NodeChain nodeChain)
        {

        }
    }
}