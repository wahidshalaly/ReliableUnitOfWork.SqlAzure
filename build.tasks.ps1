properties {
	# base & build directories
	$base_dir = . resolve-path .\
	$tests_dir = "$base_dir\src\ReliableUnitOfWork.SqlAzure.UnitTests\bin\Release"

	# .net framework version
	$framework = "4.5.1"
	
	# solution file & unit tests
	$sln_file = "$base_dir\src\ReliableUnitOfWork.SqlAzure.sln"
	$unit_tests = "$tests_dir\ReliableUnitOfWork.SqlAzure.UnitTests.dll"
	$nuspec_file = "$base_dir\src\ReliableUnitOfWork.SqlAzure\ReliableUnitOfWork.SqlAzure.csproj"
}

task default -depends PackNuGetPackages

task GitVersion {
	$assemblyVersion = (gitversion | Out-String | ConvertFrom-Json).AssemblySemVer
	Write-Host "Current Assemby Version (from GitVersion): $assemblyVersion"
}

task RestoreNuGetPackages -depends GitVersion {
	exec { nuget.exe restore $sln_file }
}

task BuildSolution -depends RestoreNuGetPackages {
	exec { msbuild "/t:Clean;Rebuild" "/p:configuration=Release;OutDir=$build_dir" $sln_file }
}

task RunUnitTests -depends BuildSolution {
	exec { xunit.console.clr4.bat $unit_tests }
}

task PackNuGetPackages -depends RunUnitTests {
	exec { nuget.exe pack $nuspec_file }
}
