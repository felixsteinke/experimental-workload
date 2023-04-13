#!/bin/bash

# Set the container name or ID
CONTAINER_NAME_OR_ID=sorting-api
# Set the output file name
OUTPUT_FILE="$CONTAINER_NAME_OR_ID-stats.csv"
# Set the seconds for break between stats
SLEEP_SECONDS=5

# Delete the old output file if it exists
if [ -f "$OUTPUT_FILE" ]; then
    rm "$OUTPUT_FILE"
fi

# Create a new output file with headers
echo "Timestamp, CPU_Usage, Memory_Usage, Disk_Read, Disk_Write, Network_Input, Network_Output" > "$OUTPUT_FILE"

while true
do
    # Get the current date and time
    timestamp=$(date +"%H:%M:%S")

    # Get the docker stats for the container and extract the relevant data
    stats=$(docker stats --no-stream --format "{{.CPUPerc}},{{.MemUsage}},{{.BlockIO}},{{.NetIO}}" "$CONTAINER_NAME_OR_ID")
    cpu_usage=$(echo "$stats" | cut -d ',' -f 1 | tr -d ' ')
    memory_usage=$(echo "$stats" | cut -d ',' -f 2 | tr -d ' ')
    disk_read=$(echo "$stats" | cut -d ',' -f 3 | cut -d '/' -f 1 | tr -d ' ')
    disk_write=$(echo "$stats" | cut -d ',' -f 3 | cut -d '/' -f 2 | tr -d ' ')
    net_input=$(echo "$stats" | cut -d ',' -f 4 | cut -d '/' -f 1 | tr -d ' ')
    net_output=$(echo "$stats" | cut -d ',' -f 4 | cut -d '/' -f 2 | tr -d ' ')

    # Append the data to the output file
    echo "$timestamp, $cpu_usage, $memory_usage, $disk_read, $disk_write, $net_input, $net_output" >> "$OUTPUT_FILE"

    # Wait for 5 seconds before the next iteration
    sleep $SLEEP_SECONDS
done
