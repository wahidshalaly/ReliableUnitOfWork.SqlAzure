properties {
	$base_dir = . resolve-path .\

	# .net framework version
	$framework = "4.5.1"

	# tools folders/files
	$tools_dir = "$base_dir\tools"
	$nuget_dir = "$tools_dir\NuGet.CommandLine.2.8.0"
	$xunit_dir = "$tools_dir\xunit.runners.1.9.2"

	# src & build folders/files
	$build_dir = "$base_dir\Build"
	$sln_file = "$base_dir\src\ReliableUnitOfWork.SqlAzure.sln"
	$unit_tests = "$build_dir\ReliableUnitOfWork.SqlAzure.UnitTests.dll"
}

task default -depends run_tests

task clean {
	exec { Remove-Item $build_dir -Recurse -ErrorAction SilentlyContinue }
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
