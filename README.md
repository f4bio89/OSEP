# OSEP

# OSEP Operator Notes

> A practical knowledge base, operator playbook, and offensive tooling repository built during my PEN-300 (OSEP) preparation.

## Overview

This repository contains the notes, attack paths, command references, and tooling I developed while studying the PEN-300 course and preparing for the Offensive Security Experienced Penetration Tester (OSEP) certification.

One of the biggest lessons I learned during this journey was that success in OSEP starts long before exam day. Completing labs is important, but building a structured knowledge base and developing repeatable workflows proved to be equally valuable.

Using these notes, together with completing all PEN-300 challenges, I was able to capture all required OSEP exam flags in approximately **14 hours**.

The objective of this repository is to consolidate offensive security knowledge into a single place that can be quickly referenced during labs, red team exercises, research, and future training.

---

## What's Included

### Operator Notes

The notes are organized around offensive security objectives rather than course chapters and cover topics such as:

- Basic Commands
- Phishing techniques
- Microsoft Word macros
- AMSI bypass techniques
- UAC bypass techniques
- Constrained Language Mode (CLM) bypasses
- Remote Desktop Configuration
- Process Injection
- DLL Injection Payloads
- Process hollowing
- Reflective DLL Injection
- Mimikatz
- Active Directory attack paths
- MSSQL attacks
- BloodHound workflows
- Kerberos attacks
---

# Offensive Tooling

In addition to notes, this repository includes several helper scripts and proof-of-concept projects developed during training.

## Payload Automation

| Tool | Description |
|--------|-------------|
| `gen_hollow_vba.py` | Generates VBA process hollowing payloads for Microsoft Word macros |
| `xor_vba.py` | Generates XOR-encoded VBA payloads |
| `xor_csharp.py` | Generates XOR-encoded shellcode for C# projects |
| `xor_ps1.py` | Generates XOR-encoded shellcode for PowerShell loaders |

## Process Injection Projects

| Project | Description |
|----------|-------------|
| Process Injection | Remote process injection |
| Remote Process Injection | Download and execute payloads directly in memory |
| Self Injection | Local shellcode injection |
| Self Injection Obfuscated | Obfuscated self-injection variant |
| Hollow | Process hollowing |
| HollowEvasion | Process hollowing with evasion techniques |
| DLLInjector | DLL injection |
| SharpReflectivePEInjection | Reflective PE injection |

---

## Client-Side Execution

| Project | Description |
|----------|-------------|
| DotNetToJScript | .NET execution through JScript |
| JScript Runner | JScript payload execution |

---

## Evasion and Bypass

| Project | Description |
|----------|-------------|
| CLM_Bypass | Constrained Language Mode bypass |
| PrintSpoofer | Privilege escalation helper |

---

# Repository Philosophy

The goal of these notes is not to provide walkthroughs for specific labs.

Instead, the focus is on:

- Building repeatable attack workflows
- Organizing offensive knowledge
- Reducing cognitive load during engagements
- Creating reusable operator playbooks
- Accelerating execution during labs and assessments
- Documenting lessons learned from every challenge completed

---

# Disclaimer

This repository is intended for:

- Educational purposes
- Lab environments
- Authorized security assessments
- Red Team training
- Offensive security research

The author does not condone unauthorized access to systems or misuse of the information contained in this repository.

