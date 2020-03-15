using System;
using Xunit;
using NuGet.Common;

namespace NuGet.CommandLine.Test
{
    /// <summary>
    /// This attribute ensures the Fact is only run on Windows.
    /// </summary>
    public class WindowsNTFactAttribute
        : FactAttribute
    {
        public WindowsNTFactAttribute()
        {
        }

        private string _skip;

        public override string Skip
        {
            get
            {
                var skip = _skip;

                if (string.IsNullOrEmpty(skip))
                {
                    if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                    {
                        Skip = "Test only runs on Windows NT or later.";
                    }
                }

                // If this is null the test will run.
                return skip;
            }

            set
            {
                _skip = value;
            }
        }
    }

    public class UnixMonoFactAttribute
        : FactAttribute
    {
        public UnixMonoFactAttribute()
        {
            if (!RuntimeEnvironmentHelper.IsMono || RuntimeEnvironmentHelper.IsWindows)
            {
                Skip = "Test only runs with mono on Unix.";
            }
        }
    }

    public class SkipMonoAttribute 
        : FactAttribute
    {
        public SkipMonoAttribute()
        {
            if (RuntimeEnvironmentHelper.IsMono)
            {
                Skip = "Skip this test on mono for now.";
            }
        }
    }

    public class SkipMonoTheoryAttribute
       : TheoryAttribute
    {
        public SkipMonoTheoryAttribute()
        {
            if (RuntimeEnvironmentHelper.IsMono)
            {
                Skip = "Skip this test on mono for now.";
            }
        }
    }
}
