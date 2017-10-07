declare -x path=$1

if [ -z "$path" ]; then 
    $path="$(pwd)/../src";
    echo -e "\e[33mNo path passed. Will use $path"
fi

declare -a projectList=(
    "$path/Exline.Notifier"
    "$path/Exline.Notifier.Data"
    "$path/Exline.Notifier.Core"
    "$path/Exline.Notifier.Web.Api"
)

for project in "${projectList[@]}"
do
    echo -e "\tWorking on $path/$project"
    echo -e "\tRemoving old publish output"
    pushd $path/$project
    rm -rf ./publish
    echo -e "\tBuilding and publishing $project"
    dotnet publish -c Release -o ./publish --verbosity quiet
    popd
done