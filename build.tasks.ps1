properties {
	# .net framework version
	$framework = "4.5.1"

	# project version - not in function yet
	$version = "0.4.2"

	# src & build folders/files
	$base_dir = . resolve-path .\
	$build_dir = "$base_dir\Build"
	$nuget_dir = "$base_dir\src\packages\NuGet.CommandLine.2.8.0\tools\" #nuget.exe
	$xunit_dir = "$base_dir\src\packages\xunit.runners.1.9.2\tools" #xunit.console.clr4.exe
	$sln_file = "$base_dir\src\ReliableUnitOfWork.SqlAzure.sln"
	$unit_tests = "$build_dir\ReliableUnitOfWork.SqlAzure.UnitTests.dll"
}

task default -depends run_tests

task clean {
	exec { Remove-Item $build_dir -Recurse }
}

task restore_nuget_packages -depends clean {
	& $nuget_dir\nuget.exe restore $sln_file
}

task build_solution -depends restore_nuget_packages {
	exec { msbuild /t:build "/p:configuration=Release;OutDir=$build_dir" $sln_file }
}

task run_tests -depends build_solution {
	& $xunit_dir\xunit.console.clr4.exe $unit_tests
}
