// include Fake libs
#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Testing.XUnit2

// Directories
let buildDir  = "./.build"

// Targets

Target "Clean" (fun _ ->
    [buildDir]
    |> Seq.iter CleanDir
)

let appReferences  =
    !! "./**/*.csproj"

Target "Build" (fun _ ->
    MSBuildDebug buildDir "Build" appReferences
    |> Log "AppBuild-Output: "
)

Target "Test" (fun _ ->
    let target = buildDir
    !! (target @@ "DoctorAppointment.IntegrationTests.dll")
        //++ (target @@ "DoctorAppointment.UnitTests.dll")
        |> xUnit2 (fun p ->
            {p with
                ShadowCopy = false
                ToolPath = @"./packages/xunit.runner.console/tools/xunit.console.exe" 
                })
)

"Clean"
  ==> "Build"
  ==> "Test"

// start build
RunTargetOrDefault "Test"
