properties {
	# build variables
	$framework = "4.5.1"		# .net framework version
	$configuration = "Release"	# build configuration
	
	# directories
	$base_dir = . resolve-path .\
	$tests_dir = "$base_dir\src\ReliableUnitOfWork.SqlAzure.UnitTests\bin\$configuration"

	# files
	$sln_file = "$base_dir\src\ReliableUnitOfWork.SqlAzure.sln"
	$unit_tests = "$tests_dir\ReliableUnitOfWork.SqlAzure.UnitTests.dll"
	$nuspec_file = "$base_dir\src\ReliableUnitOfWork.SqlAzure\ReliableUnitOfWork.SqlAzure.nuspec"
}

task default -depends PackNuGetPackages

task RestoreNuGetPackages {
	exec { nuget.exe restore $sln_file }
}

task BuildSolution -depends RestoreNuGetPackages {
	exec { msbuild "/t:Clean;Build" "/p:Configuration=$configuration" $sln_file }
}

task RunUnitTests -depends BuildSolution {
	exec { xunit.console.clr4.bat $unit_tests }
}

task PackNuGetPackages -depends RunUnitTests {
	# assembly version  calculated by GitVersion
	$version = (gitversion | Out-String | ConvertFrom-Json).NuGetVersion
	Write-Host "NuGet Version (calculated by GitVersion): $version"
	exec { nuget.exe pack $nuspec_file -Version $version -Prop Configuration=$configuration -Symbols -Verbosity detailed }
}
