import zipfile
import plistlib
import os
import sys

def extract_bundle_id(ipa_path):
    temp_dir = "temp_extract"
    try:
        # Step 1: Extract IPA file (ZIP format)
        with zipfile.ZipFile(ipa_path, 'r') as ipa:
            ipa.extractall(temp_dir)

        # Step 2: Locate Info.plist
        for root, dirs, files in os.walk(temp_dir):
            for file in files:
                if file == "Info.plist":
                    plist_path = os.path.join(root, file)
                    with open(plist_path, 'rb') as plist_file:
                        plist_data = plistlib.load(plist_file)
                        return plist_data.get("CFBundleIdentifier")
    finally:
        # Cleanup extracted files
        if os.path.exists(temp_dir):
            for root, dirs, files in os.walk(temp_dir, topdown=False):
                for name in files:
                    os.remove(os.path.join(root, name))
                for name in dirs:
                    os.rmdir(os.path.join(root, name))
            os.rmdir(temp_dir)

    return None


if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("Usage: python extract_bundle_id.py <path_to_ipa>")
        sys.exit(1)

    ipa_path = sys.argv[1]
    if not os.path.isfile(ipa_path):
        print(f"Error: File not found - {ipa_path}")
    else:
        bundle_id = extract_bundle_id(ipa_path)
        if bundle_id:
            print(f"Bundle ID: {bundle_id}")
