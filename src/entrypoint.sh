#!/bin/bash
SecondsToWaitToStartBackend=5

echo "Waiting ${SecondsToWaitToStartBackend} seconds to start backend"

sleep $SecondsToWaitToStartBackend;

echo "Backend starting..."

dotnet Web.API.dll