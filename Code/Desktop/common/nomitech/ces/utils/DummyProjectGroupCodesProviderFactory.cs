namespace Desktop.common.nomitech.ces.utils
{
    using ProjectDBUtil = Desktop.common.nomitech.common.ProjectDBUtil;
    using BaseCache = Desktop.common.nomitech.common.@base.BaseCache;
    using GroupCode = Desktop.common.nomitech.common.@base.GroupCode;
    using ProjectGroupCodesProvider = Desktop.common.nomitech.common.@base.ProjectGroupCodesProvider;
    using ProjectGroupCodesProviderFactory = Desktop.common.nomitech.common.@base.ProjectGroupCodesProviderFactory;

    public class DummyProjectGroupCodesProviderFactory : ProjectGroupCodesProviderFactory
    {
        public virtual ProjectGroupCodesProvider createNewFactory(ProjectDBUtil paramProjectDBUtil)
        {
            //JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
            //ORIGINAL LINE: final nomitech.common.base.BaseCache bCache = new nomitech.common.base.BaseCache()
            BaseCache bCache = new BaseCacheAnonymousInnerClass(this);
            return new ProjectGroupCodesProviderAnonymousInnerClass(this, bCache);
        }

        private class BaseCacheAnonymousInnerClass : BaseCache
        {
            private readonly DummyProjectGroupCodesProviderFactory outerInstance;

            public BaseCacheAnonymousInnerClass(DummyProjectGroupCodesProviderFactory outerInstance)
            {
                this.outerInstance = outerInstance;
            }

            public int getLevelOfGroupCode(GroupCode param1GroupCode)
            {
                return 0;
            }

            public GroupCode getGroupCode(string param1String)
            {
                return null;
            }
        }

        private class ProjectGroupCodesProviderAnonymousInnerClass : ProjectGroupCodesProvider
        {
            private readonly DummyProjectGroupCodesProviderFactory outerInstance;

            private BaseCache bCache;

            public ProjectGroupCodesProviderAnonymousInnerClass(DummyProjectGroupCodesProviderFactory outerInstance, BaseCache bCache)
            {
                this.outerInstance = outerInstance;
                this.bCache = bCache;
            }

            public string getUnitAlias(string param1String)
            {
                return "";
            }

            public string getGroupCodeStyle(short param1Short)
            {
                return "dotted";
            }

            public string getGroupCodeSeparator(short param1Short)
            {
                return "";
            }

            public BaseCache getGroupCodeCache(short param1Short)
            {
                return bCache;
            }

            public string GroupCode9Separator
            {
                get
                {
                    return "";
                }
            }

            public string GroupCode9CodeStyle
            {
                get
                {
                    return "";
                }
            }

            public BaseCache GroupCode9Cache
            {
                get
                {
                    return bCache;
                }
            }

            public string GroupCode8Separator
            {
                get
                {
                    return "";
                }
            }

            public string GroupCode8CodeStyle
            {
                get
                {
                    return "";
                }
            }

            public BaseCache GroupCode8Cache
            {
                get
                {
                    return bCache;
                }
            }

            public string GroupCode7Separator
            {
                get
                {
                    return "";
                }
            }

            public string GroupCode7CodeStyle
            {
                get
                {
                    return "";
                }
            }

            public BaseCache GroupCode7Cache
            {
                get
                {
                    return bCache;
                }
            }

            public string GroupCode6Separator
            {
                get
                {
                    return "";
                }
            }

            public string GroupCode6CodeStyle
            {
                get
                {
                    return "";
                }
            }

            public BaseCache GroupCode6Cache
            {
                get
                {
                    return bCache;
                }
            }

            public string GroupCode5Separator
            {
                get
                {
                    return "";
                }
            }

            public string GroupCode5CodeStyle
            {
                get
                {
                    return "";
                }
            }

            public BaseCache GroupCode5Cache
            {
                get
                {
                    return bCache;
                }
            }

            public string GroupCode4Separator
            {
                get
                {
                    return "";
                }
            }

            public string GroupCode4CodeStyle
            {
                get
                {
                    return "";
                }
            }

            public BaseCache GroupCode4Cache
            {
                get
                {
                    return bCache;
                }
            }

            public string GroupCode3Separator
            {
                get
                {
                    return "";
                }
            }

            public string GroupCode3CodeStyle
            {
                get
                {
                    return "";
                }
            }

            public BaseCache GroupCode3Cache
            {
                get
                {
                    return bCache;
                }
            }

            public string GroupCode2Separator
            {
                get
                {
                    return "";
                }
            }

            public string GroupCode2CodeStyle
            {
                get
                {
                    return "";
                }
            }

            public BaseCache GroupCode2Cache
            {
                get
                {
                    return bCache;
                }
            }

            public string GroupCode1Separator
            {
                get
                {
                    return "";
                }
            }

            public string GroupCode1CodeStyle
            {
                get
                {
                    return "";
                }
            }

            public BaseCache GroupCode1Cache
            {
                get
                {
                    return bCache;
                }
            }

            public string EpsCodeStyle
            {
                get
                {
                    return "";
                }
            }

            public string EpsCodeSeparator
            {
                get
                {
                    return "";
                }
            }

            public BaseCache EpsCache
            {
                get
                {
                    return bCache;
                }
            }

            public void initializeProjectCaches()
            {
            }

            public string Wbs2Separator
            {
                get
                {
                    return "";
                }
            }

            public BaseCache Wbs2Cache
            {
                get
                {
                    return bCache;
                }
            }

            public string Wbs1Separator
            {
                get
                {
                    return "";
                }
            }

            public BaseCache Wbs1Cache
            {
                get
                {
                    return bCache;
                }
            }

            public string getProjectProperty(string param1String)
            {
                return "";
            }

            public string ParamItemSeparator
            {
                get
                {
                    return "";
                }
            }

            public BaseCache ParamItemCache
            {
                get
                {
                    return bCache;
                }
            }

            public string LocationSeparator
            {
                get
                {
                    return "";
                }
            }

            public BaseCache LocationCache
            {
                get
                {
                    return bCache;
                }
            }
        }

        public virtual ProjectGroupCodesProvider createSharedFactory()
        {
            return createNewFactory(null);
        }
    }


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\ce\\utils\DummyProjectGroupCodesProviderFactory.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}